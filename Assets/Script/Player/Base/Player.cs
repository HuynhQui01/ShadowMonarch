using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IPlayerDamageable, IPlayerMoveable

{
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    [field: SerializeField] public float MaxArmor { get; set; } = 50f;
    public float CurrentArmor { get; set; }
    [field: SerializeField] public float Damage { get; set; }
    [field: SerializeField] public float MoveSpeed { get; set; } = 2f;
    [field: SerializeField] public float Defence { get; set; }
    [field: SerializeField] public float Experience { get; set; }
    [field: SerializeField] public int Level { get; set; }
    [field: SerializeField] public float MaxExperience { get; set; } = 5f;
    [field: SerializeField] public float FreePoints { get; set; }
    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; } = true;
    [field: SerializeField] public int coin { get; set; }

    public PlayerStateMachine playerStateMachine { get; set; }
    public PlayerAttackState playerAttackState { get; set; }
    public PlayerMoveState playerMovementState { get; set; }
    public PlayerDashState playerDashState { get; set; }
    public PlayerIdleState playerIdleState { get; set; }
    public PlayerGetHitState playerGetHitState { get; set; }
    public PlayerUseSkillState playerUseSkillState { get; set; }
    public static Player Instance;

    #region Equipments 
    [SerializeField] public List<Equipments> equipmentsList;
    #endregion
    #region Items
    [SerializeField] public List<Items> itemsList;
    #endregion

    public Animator animator;
    public PlayerAction playerAction;
    public Vector2 movementInput;
    public SwordHitBox swordHitBox;
    public SkillManager skillManager;
    public DashEffect dashEffect;
    public SpriteRenderer spriteRenderer;
    public float regenArmorRate = 2f;
    private float regenCooldown = 0.5f;
    private float lastRegenTime;
    public float damageCooldown = 3f;
    private float lastDamageTime;
    public Healthbar healthbars;
    public ArmorBar armorBar;
    public InventoryManager inventoryManager;
    public TargetArea targetArea;
    public SkillUIPanel SkillUIPanel;
    public bool canMove = true;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerStateMachine = new PlayerStateMachine();
        playerAttackState = new PlayerAttackState(this, playerStateMachine);
        playerMovementState = new PlayerMoveState(this, playerStateMachine);
        playerDashState = new PlayerDashState(this, playerStateMachine);
        playerIdleState = new PlayerIdleState(this, playerStateMachine);
        playerUseSkillState = new PlayerUseSkillState(this, playerStateMachine);
        playerGetHitState = new PlayerGetHitState(this, playerStateMachine);
        playerAction = new PlayerAction();
        animator = GetComponent<Animator>();
        dashEffect = GetComponent<DashEffect>();
        swordHitBox = GetComponent<SwordHitBox>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventoryManager = GetComponentInChildren<InventoryManager>();
        targetArea = GetComponentInChildren<TargetArea>();
        SkillUIPanel = GetComponentInChildren<SkillUIPanel>();
        playerAction.Enable();
        healthbars.SetMaxHealth(MaxHealth);
        armorBar.SetMaxArmor(MaxArmor);
        // LoadGame();
    }



    void Start()
    {
        playerStateMachine.Initialize(playerIdleState);
        dashEffect.enabled = false;
        RB = GetComponent<Rigidbody2D>();
        Damage = 10f;
        playerAction.SaveAndLoad.Save.started += _ => SaveGame();
        playerAction.SaveAndLoad.Load.started += _ => LoadGame();
        playerAction.Inventory.Open.started += _ => InventoryShowAndHide();
        playerAction.SkillPanel.OpenSkillPanel.started += _ => OpenSkillPanel();
        playerAction.SkillPanel.CloseSkillPanel.started += _ => CloseSkillPanel();
        lastRegenTime = Time.time;
        lastDamageTime = -damageCooldown;
        CurrentHealth = MaxHealth;
        CurrentArmor = MaxArmor;

        Debug.Log(MaxHealth);
    }

    void OpenSkillPanel()
    {
        SkillUIPanel.gameObject.SetActive(true);
        Debug.Log("Open Skill Panel");
        Time.timeScale = 0;
    }

    void CloseSkillPanel()
    {
        SkillUIPanel.gameObject.SetActive(false);
        SkillUIPanel.skillDetail.SetActive(false);
        Time.timeScale = 1;
    }

    private void InventoryShowAndHide()
    {
        inventoryManager.OpenAndCloseInventory();
        Attribute();
        EquipItem();

    }

    public void Attribute()
    {
        ResetAttribute();
        for (int i = 0; i < inventoryManager.equipmentSlots.Length; i++)
        {
            if (inventoryManager.equipmentSlots[i].isFull == true)
            {
                MaxHealth += inventoryManager.equipmentSlots[i].equipments.health;
                Damage += inventoryManager.equipmentSlots[i].equipments.damage;
                Defence += inventoryManager.equipmentSlots[i].equipments.defence;

            }
            equipmentsList.Add(inventoryManager.equipmentSlots[i].equipments);
        }

        Debug.Log(MaxHealth);
    }

    public void SetAttributeWhenEquip(Equipments equipments)
    {
        MaxHealth += equipments.health;
        Damage += equipments.damage;
        Defence += equipments.defence;
        MoveSpeed += equipments.movementSpeed;

        Debug.Log(MaxHealth);
    }
    public void SetAttributeWhenUnequip(Equipments equipments)
    {
        MaxHealth -= equipments.health;
        Damage -= equipments.damage;
        Defence -= equipments.defence;
        MoveSpeed -= equipments.movementSpeed;
        Debug.Log(MaxHealth);
    }

    private void CheckLevel()
    {
        if (Level > 0)
        {
            MaxHealth = MaxHealth + ((float)PlusPointLevelUp.Health * Level);
            MaxArmor = MaxArmor + ((float)PlusPointLevelUp.Armor * Level);
            Defence = Defence + ((float)PlusPointLevelUp.Defence * Level);
            MaxExperience = MaxExperience + ((float)PlusPointLevelUp.MaxExperience * Level);
            FreePoints = FreePoints + ((float)PlusPointLevelUp.FreePoints * Level);
        }
    }

    private void EquipItem()
    {
        for (int i = 0; i < inventoryManager.itemSlot.Length; i++)
        {
            itemsList.Add(inventoryManager.itemSlot[i].item);
        }
    }

    void ResetAttribute()
    {
        MaxHealth = 100f;
        Damage = 10f;
        Defence = 0f;
    }

    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootstepSound
    }

    void Update()
    {
        if (Experience >= MaxExperience)
        {
            LevelUp();
        }
        movementInput = playerAction.Movement.Move.ReadValue<Vector2>();
        playerStateMachine.currentPlayerState.FrameUpdate();
        if (CurrentArmor < MaxArmor && Time.time >= lastRegenTime + regenCooldown && Time.time >= lastDamageTime + damageCooldown)
        {
            RegenerateArmor();
            lastRegenTime = Time.time;
        }
    }

    void LevelUp()
    {
        Level++;
        MaxExperience *= 1.5f;
        Experience = 0f;
        MaxHealth += 10f;
        MaxArmor += 5f;
        Damage += 5f;
        regenArmorRate += 0.5f;
        FreePoints += 5f;
        Debug.Log("Level Up!");
    }

    public void RegenerateArmor()
    {
        
        CurrentArmor += regenArmorRate;
        armorBar.SetArmor(CurrentArmor);
        Debug.Log(CurrentArmor);
        if (CurrentArmor > MaxArmor)
        {
            CurrentArmor = MaxArmor;
        }
    }

    void FixedUpdate()
    {
        playerStateMachine.currentPlayerState.PhysicsUpdate();
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if (!IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        else if (IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }

    public void Die()
    {

    }

    public void TakeDamage(float damageAmout)
    {
        if (CurrentArmor > 0)
        {
            CurrentArmor -= damageAmout;
            armorBar.SetArmor(CurrentArmor);
        }
        else
        {
            CurrentHealth -= damageAmout;
            healthbars.SetHealth(CurrentHealth);
        }
        lastDamageTime = Time.time;
        playerStateMachine.ChangeState(playerGetHitState);
        Debug.Log(CurrentHealth);
        if (CurrentHealth <= 0) Die();
    }

    public void SaveGame()
    {
        GameData data = new GameData(this);
        SaveLoadManager.SaveGame(data);
        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        GameData data = SaveLoadManager.LoadGame();
        if (data != null)
        {
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;
            coin = data.coin;

            Experience = data.experience;
            Level = data.level;
            CheckLevel();
            MaxExperience = data.MaxExperience;

            equipmentsList = data.equipmentsList;
            itemsList = data.itemsList;
            for (int i = 0; i < equipmentsList.Count; i++)
            {
                inventoryManager.LoadEquipment(equipmentsList[i]);
            }

            for (int i = 0; i < itemsList.Count; i++)
            {
                inventoryManager.LoadItems(itemsList[i]);
            }

            // score = data.score;
            Debug.Log("Game Loaded");
        }
    }

    enum PlusPointLevelUp
    {
        Health = 5,
        Armor = 5,
        Damage = 5,
        Defence = 5,
        MaxExperience = 2,
        FreePoints = 5

    }

}
