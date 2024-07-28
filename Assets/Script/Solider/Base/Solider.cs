using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider : MonoBehaviour, ISoliderDamageable, ISoliderMoveable, ITriggerCheckable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    [field: SerializeField] public SoliderAttackBox Hitbox;
    public float CurrentHealth { get; set; }
    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; } = true;
    public SoliderStateMachine StateMachine { get; set; }
    public SoliderAttackState AttackState { get; set; }
    public SoliderIdleState IdleState { get; set; }
    public SoliderMoveState MoveState { get; set; }
    public SoliderGetHitState GetHitState { get; set; }
    public SoliderDeadState DeadState { get; set; }

    [SerializeField] private SoliderIdleSOBase SoliderIdleBase;
    [SerializeField] private SoliderMoveSOBase SoliderMoveBase;
    [SerializeField] private SoliderAttackSOBase SoliderAttackBase;
    public SoliderIdleSOBase SoliderIdleBaseInstance { get; set; }
    public SoliderMoveSOBase SoliderMoveBaseInstance { get; set; }
    public SoliderAttackSOBase SoliderAttackBaseInstance { get; set; }

    public bool IsAggroed { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    public Animator animator;
    public bool takeHit = false;
    public Player player;
    public bool isDead = false;
    public SoliderDetectZone soliderDetectZone;

    void Awake()
    {
        SoliderIdleBaseInstance = Instantiate(SoliderIdleBase);
        SoliderMoveBaseInstance = Instantiate(SoliderMoveBase);
        SoliderAttackBaseInstance = Instantiate(SoliderAttackBase);

        StateMachine = new SoliderStateMachine();
        AttackState = new SoliderAttackState(this, StateMachine);
        IdleState = new SoliderIdleState(this, StateMachine);
        MoveState = new SoliderMoveState(this, StateMachine);
        GetHitState = new SoliderGetHitState(this, StateMachine);
        DeadState = new SoliderDeadState(this, StateMachine);
        player = FindObjectOfType<Player>();

    }

    void Start()
    {
        CurrentHealth = MaxHealth;
        RB = GetComponent<Rigidbody2D>();
        SoliderIdleBaseInstance.Initialize(gameObject, this);
        SoliderMoveBaseInstance.Initialize(gameObject, this);
        SoliderAttackBaseInstance.Initialize(gameObject, this);
        animator = GetComponent<Animator>();
        StateMachine.Initialize(IdleState);
        Hitbox = GetComponentInChildren<SoliderAttackBox>();
    }

    void Update()
    {
        StateMachine.CurrentSoliderState.FrameUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.CurrentSoliderState.PhysicsUpdate();
    }





    public void Damage(float damageAmout)
    {
        CurrentHealth -= damageAmout;
        takeHit = true;
        Debug.Log("hit");
        if (CurrentHealth <= 0)
        {
            StateMachine.ChangeState(DeadState);
        }
    }

    public void Die()
    {
        // Destroy(gameObject);
        isDead = true;
    }

    public void MoveSolider(Vector2 velocity)
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
