using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IPlayerDamageable, IPlayerMoveable, ICollection
{
    [field: SerializeField]public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    [field: SerializeField]public float MaxArmor { get; set; } = 50f;
    public float CurrentArmor { get; set; }
    [field: SerializeField]public float Damage {get; set; }
    [field: SerializeField]public float MoveSpeed { get; set; }
    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; } = true;
    [field: SerializeField] public int coin { get ; set; }
    [field: SerializeField] public List<GameObject> items { get; set; }

    public PlayerStateMachine playerStateMachine { get; set; }
    public PlayerAttackState playerAttackState { get; set; }
    public PlayerMoveState playerMovementState { get; set; }
    public PlayerDashState playerDashState { get; set; }
    public PlayerIdleState playerIdleState { get; set; }

    #region Item 
    [field: SerializeField] public BloodKnightHelmet Item ;
    public BloodKnightHelmet helmet {get; set; }
    #endregion

    public Animator animator;
    public PlayerAction playerAction;
    public Vector2 movementInput;
    public SwordHitBox swordHitBox;
    public DashEffect dashEffect;
    public SpriteRenderer spriteRenderer;
    public float regenArmorRate = 2f; 
    private float regenCooldown = 0.5f; 
    private float lastRegenTime; 
    public float damageCooldown = 3f; 
    private float lastDamageTime;
    public Healthbar healthbars;
    public ArmorBar armorBar;
    public UIInventory uIInventory;



    void Awake()
    {
        playerStateMachine = new PlayerStateMachine();
        playerAttackState = new PlayerAttackState(this, playerStateMachine);
        playerMovementState = new PlayerMoveState(this, playerStateMachine);
        playerDashState = new PlayerDashState(this, playerStateMachine);
        playerIdleState = new PlayerIdleState(this, playerStateMachine);
        playerAction = new PlayerAction();
        animator = GetComponent<Animator>();
        dashEffect = GetComponent<DashEffect>();
        swordHitBox = GetComponent<SwordHitBox>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        uIInventory = FindAnyObjectByType<UIInventory>();
        playerAction.Enable();
        healthbars.SetMaxHealth(MaxHealth);
        armorBar.SetMaxArmor(MaxArmor);

        CheckNull();
    }

    private void CheckNull(){
        if(Item){
            helmet = Instantiate(Item);
        }
    }

    void Start(){
        CurrentHealth = MaxHealth;
        CurrentArmor = MaxArmor;
        lastRegenTime = Time.time; 
        lastDamageTime = -damageCooldown;
        RB = GetComponent<Rigidbody2D>();
        playerStateMachine.Initialize(playerIdleState);
        dashEffect.enabled = false;
        Damage = 10f;
        playerAction.SaveAndLoad.Save.started +=_=> SaveGame();
        playerAction.SaveAndLoad.Load.started += _=> LoadGame();
        playerAction.Inventory.Open.started += _=> InventoryShowAndHide();
        InventoryShowAndHide();
        Debug.Log(MaxHealth);
    }

    private void InventoryShowAndHide()
    {
        uIInventory.ShowAndHide();
        Debug.Log("CLose");
    }

   

    public enum AnimationTriggerType{
        EnemyDamaged,
        PlayFootstepSound
    }

    void Update(){
        movementInput = playerAction.Movement.Move.ReadValue<Vector2>();
        playerStateMachine.currentPlayerState.FrameUpdate();
        if(CurrentArmor < MaxArmor && Time.time >= lastRegenTime + regenCooldown && Time.time >= lastDamageTime + damageCooldown){
            RegenerateArmor();
            lastRegenTime = Time.time;
        }
    }

    public void RegenerateArmor(){
        CurrentArmor += regenArmorRate;
        armorBar.SetArmor(CurrentArmor);
        Debug.Log(CurrentArmor);
         if (CurrentArmor > MaxArmor)
        {
            CurrentArmor = MaxArmor; 
        }
    }

    void FixedUpdate(){
        playerStateMachine.currentPlayerState.PhysicsUpdate();
    }

    private void AnimationTriggerEvent(AnimationTriggerType triggerType){
        playerStateMachine.currentPlayerState.AnimationTriggerEvent(triggerType);
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
       if(!IsFacingRight && velocity.x< 0f){
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }else if(IsFacingRight && velocity.x > 0f){
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
            Item = data.helmet;
            MaxHealth += data.helmet.health;
        Debug.Log(MaxHealth);
            
            // score = data.score;
            Debug.Log("Game Loaded");
        }
    }

    
}
