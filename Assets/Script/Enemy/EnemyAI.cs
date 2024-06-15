using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State{
        Roaming
    }
    

    State state;
    EnemyPathFinding enemyPathFinding;
    void Awake(){
        enemyPathFinding = GetComponent<EnemyPathFinding>();
        state = State.Roaming;
    }

    void Start(){
        // StartCoroutine(RoamingRoutine());
    }

    void FixedUpdate(){
        
    }

    IEnumerator RoamingRoutine(){
        while(state == State.Roaming){
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathFinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    Vector2 GetRoamingPosition(){
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

   
}
