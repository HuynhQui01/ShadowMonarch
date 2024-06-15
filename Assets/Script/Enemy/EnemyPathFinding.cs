using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8000f;
    Rigidbody2D rb;
    Vector2 moveDir;
    public DetectedZone detectedZone;

    SpriteRenderer spriteRenderer;
    EnemyController enemyController;


    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        enemyController = GetComponent<EnemyController>();
    }

    void FixedUpdate(){
        if (enemyController.canMove)
        {
            if (detectedZone.detectedObjects.Count > 0)
            { 
                Vector2 direction = (detectedZone.detectedObjects[0].transform.position - transform.position).normalized;
                if(direction.x > 0){
                    spriteRenderer.flipX = true;
                }else{
                    spriteRenderer.flipX = false;
                }
                rb.AddForce(direction * moveSpeed * Time.fixedDeltaTime);
            }
        }
        // rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.deltaTime));
    }

    public void MoveTo(Vector2 targetPosition){
        moveDir = targetPosition;
    }
}
