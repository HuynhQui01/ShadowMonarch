using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<Enemy> lstEnemies;
    public Collider2D spawnArea;
    
    public WallDoor wallDoor;
    public TranspacencyDetectionWallDoor transpacencyDetectionWallDoor;
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") ){
            StartCoroutine(OpenDoor());

            foreach(Enemy enemy in lstEnemies){
                Vector2 spawnPosition = GetRandomPositionWithinCollider();
            
                Instantiate(enemy.gameObject, spawnPosition, Quaternion.identity);
            }
            // Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            wallDoor.gameObject.SetActive(false);
            transpacencyDetectionWallDoor.gameObject.SetActive(false);
        }
    }

     Vector2 GetRandomPositionWithinCollider()
    {
        // Get the bounds of the collider
        Bounds bounds = spawnArea.bounds;

        // Generate a random position within the bounds
        float randomX = Random.Range(bounds.min.x, bounds.max.x - 0.2f);
        float randomY = Random.Range(bounds.min.y, bounds.max.y -0.2f);

        return new Vector2(randomX, randomY);
    }
    
    IEnumerator OpenDoor(){
        yield return new WaitForSeconds(0.2f);
        transpacencyDetectionWallDoor.gameObject.SetActive(true);           
        wallDoor.gameObject.SetActive(true);
    }
}
