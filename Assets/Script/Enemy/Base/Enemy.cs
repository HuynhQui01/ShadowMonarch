using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    [field: SerializeField] public float MaxHealth { get; set;} = 100f;
    [field: SerializeField] public AttackHitBoxCheck Hitbox;
    public float CurrentHealth { get; set;}
    public Rigidbody2D RB { get; set;}

    public bool IsFacingRight { get; set;} = true;

    public EnemyStateMachine StateMachine {get; set;}
    public EnemyAttackState AttackState {get; set;}
    public EnemyIdleState IdleState {get; set;}
    public EnemyMoveState MoveState {get; set;}
    public bool IsAggroed { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    public Animator animator;

    public float RandomMovementRange = 5f;
    public float RandomMovementSpeed = 0.5f;

    void Awake(){
        StateMachine = new EnemyStateMachine();
        AttackState = new EnemyAttackState(this, StateMachine);
        IdleState = new EnemyIdleState(this, StateMachine);
        MoveState = new EnemyMoveState(this, StateMachine);
    }

    void Start(){
        CurrentHealth = MaxHealth;
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StateMachine.Initialize(IdleState);
        Hitbox = GetComponent<AttackHitBoxCheck>();
    }

    void Update(){
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    void FixedUpdate(){
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public enum AnimationTriggerType{
        EnemyDamaged,
        PlayFootstepSound
    }

    private void AnimationTriggerEvent(AnimationTriggerType triggerType){
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public void Damage(float damageAmout)
    {
        CurrentHealth -= damageAmout;

        if(CurrentHealth <= 0){
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void MoveEnemy(Vector2 velocity)
    {
        RB.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
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

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetStrikingDistanceBool(bool isStrikingDistance)
    {
        IsWithinStrikingDistance = isStrikingDistance;
    }
}
