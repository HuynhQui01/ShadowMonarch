using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArea : MonoBehaviour
{
    public Rigidbody2D RB;
    public Enemy Enemy;
    public List<Enemy> enemies = new List<Enemy>();


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(Enemy){
            Enemy.isTarget.SetActive(true);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Enemy"){
            Enemy = col.GetComponent<Enemy>();
            enemies.Add(col.GetComponent<Enemy>());
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Enemy"){
            Enemy.isTarget.SetActive(false);
            Enemy = null;
            enemies.Remove(col.GetComponent<Enemy>());
        }
    }
}
