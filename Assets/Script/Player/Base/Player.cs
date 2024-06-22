using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IPlayerDamageable, IPlayerMoveable
{
    [field: SerializeField]public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    [field: SerializeField]public float MaxArmor { get; set; } = 50f;
    public float CurrentArmor { get; set; }
    [field: SerializeField]public float Damage { get; set; }
    [field: SerializeField]public float MoveSpeed { get; set; }
    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; } = true;

    public PlayerStateMachine playerStateMachine { get; set; }
    public PlayerAttackState playerAttackState { get; set; }
    public PlayerMoveState playerMovementState { get; set; }
    public PlayerDashState playerDashState { get; set; }
    public PlayerIdleState playerIdleState { get; set; }

    public Animator animator;
    public PlayerAction playerAction;
    public Vector2 movementInput;

    public DashEffect dashEffect;



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
        playerAction.Enable();

    }

    void Start(){
        CurrentHealth = MaxHealth;
        CurrentArmor = MaxArmor;
        RB = GetComponent<Rigidbody2D>();
        playerStateMachine.Initialize(playerIdleState);
        dashEffect.enabled = false;
    }

    public enum AnimationTriggerType{
        EnemyDamaged,
        PlayFootstepSound
    }

    void Update(){
        movementInput = playerAction.Movement.Move.ReadValue<Vector2>();
        playerStateMachine.currentPlayerState.FrameUpdate();
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
        
    }

    

    
}
