using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashSpeed = 4f;




    private PlayerAction playerAction;

    private Vector2 movement;
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public SwordHitBox swordHitBox;
    public DashEffect dashEffect;
    float startingMoveSpeed;
    bool canMove = true;
    bool isDashing = false;

    protected override void Awake()
    {
        base.Awake();
        swordHitBox = GetComponentInChildren<SwordHitBox>();
        playerAction = new PlayerAction();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        dashEffect = GetComponent<DashEffect>();

        playerAction.Combat.KeepingAttack.performed += _ => KeepingAttack();
        playerAction.Combat.Attack.started += _ => Attack();
        playerAction.Combat.KeepingAttack.canceled += _ => EndAttack();
        playerAction.Combat.Dash.started += _ => Dash();
        startingMoveSpeed = moveSpeed;
        dashEffect.enabled = false;
        
    }

    void OnEnable()
    {
        playerAction.Enable();
    }

    private void Update()
    {

    }

    void FixedUpdate()
    {
        if (canMove)
        {
            PlayerInput();
            Move();
        }

    }

    void PlayerInput()
    {
        if (canMove)
        {

            movement = playerAction.Movement.Move.ReadValue<Vector2>();

            if (movement != Vector2.zero)
            {
                animator.SetBool("Running", true);
                if (movement.x > 0)
                {
                    spriteRenderer.flipX = true;

                }
                else if (movement.x < 0)
                {
                    spriteRenderer.flipX = false;

                }
            }
            else
            {
                animator.SetBool("Running", false);
            }

        }
    }

    void EndAttack()
    {
        animator.SetBool("KeepingAttack", false);
        UnlockMovement();


    }

    void Attack()
    {
        animator.SetBool("Running", false);
        LockMovement();
        swordHitBox.WeaponDirection();
        animator.SetTrigger("Attack");


    }



    void KeepingAttack()
    {
        animator.SetBool("Running", false);
        LockMovement();
        swordHitBox.WeaponDirection();
        animator.SetBool("KeepingAttack", true);

    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.deltaTime));
    }

    public void LockMovement()
    {
        canMove = false;
    }
    public void UnlockMovement()
    {
        canMove = true;
    }

    void Dash()
    {
        if (!isDashing)
        {
            dashEffect.enabled = true;
            dashEffect.CreateEffect();
            isDashing = true;
            animator.SetBool("isDashing", isDashing);

            moveSpeed *= dashSpeed;
            StartCoroutine(EndDashRountine());
        }
    }

    IEnumerator EndDashRountine()
    {
        print("dash");
        float dashTime = 0.2f;
        float dashCD = 0.25f;
        yield return new WaitForSeconds(dashTime);
        dashEffect.enabled = false;
        moveSpeed = startingMoveSpeed;
        yield return new WaitForSeconds(dashCD);
        isDashing = false;
        animator.SetBool("isDashing", isDashing);


    }



}
