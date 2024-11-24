using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemyDamageable, IEnemyMoveable, ITriggerCheckable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    [field: SerializeField] public AttackHitBoxCheck Hitbox;
    public float CurrentHealth { get; set; }
    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; } = true;
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyAttackState AttackState { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyMoveState MoveState { get; set; }
    public EnemyGetHitState GetHitState { get; set; }
    public EnemyDeadState DeadState { get; set; }

    [SerializeField] private EnemyIdelSOBase EnemyIdelBase;
    [SerializeField] private EnemyMoveSOBase EnemyMoveBase;
    [SerializeField] private EnemyAttackSOBase EnemyAttackBase;
    public EnemyIdelSOBase EnemyIdleBaseInstance { get; set; }
    public EnemyMoveSOBase EnemyMoveBaseInstance { get; set; }
    public EnemyAttackSOBase EnemyAttackBaseInstance { get; set; }

    public bool IsAggroed { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    public ItemDrop itemDrop;

    public Animator animator;
    public bool takeHit = false;
    public Player player;
    public GameObject isTarget;
    public HitEffect hitEffect;
    public bool isDead = false;
    public GameObject prefab;
    public HealthText healthTextPrefab;
    public SpriteRenderer spriteRenderer;


    public void Awake()
    {
        EnemyIdleBaseInstance = Instantiate(EnemyIdelBase);
        EnemyMoveBaseInstance = Instantiate(EnemyMoveBase);
        EnemyAttackBaseInstance = Instantiate(EnemyAttackBase);

        StateMachine = new EnemyStateMachine();
        AttackState = new EnemyAttackState(this, StateMachine);
        IdleState = new EnemyIdleState(this, StateMachine);
        MoveState = new EnemyMoveState(this, StateMachine);
        GetHitState = new EnemyGetHitState(this, StateMachine);
        DeadState = new EnemyDeadState(this, StateMachine);
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
        RB = GetComponent<Rigidbody2D>();
        EnemyIdleBaseInstance.Initialize(gameObject, this);
        EnemyMoveBaseInstance.Initialize(gameObject, this);
        EnemyAttackBaseInstance.Initialize(gameObject, this);
        animator = GetComponent<Animator>();
        StateMachine.Initialize(IdleState);
        Hitbox = GetComponent<AttackHitBoxCheck>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public virtual void Damage(float damageAmout)
    {
        if (!isDead)
        {
            CurrentHealth -= damageAmout;
            takeHit = true;
            healthTextPrefab.SetText(damageAmout);
            RectTransform text = Instantiate(healthTextPrefab).GetComponent<RectTransform>();
            text.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            Canvas canvas = GameObject.FindAnyObjectByType<Canvas>();
            text.SetParent(canvas.transform);
            if (CurrentHealth <= 0)
            {
                StateMachine.ChangeState(DeadState);
            }
        }
    }

    public virtual void Die()
    {
        itemDrop.CalculateDropEquipment(transform);

        Destroy(gameObject);
        isDead = true;
        spriteRenderer.enabled = false;
        isTarget.SetActive(false);
        StartCoroutine(DestroyEnemy());
    }
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void MoveEnemy(Vector2 velocity)
    {
        RB.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
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

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetStrikingDistanceBool(bool isStrikingDistance)
    {
        IsWithinStrikingDistance = isStrikingDistance;
    }
}
