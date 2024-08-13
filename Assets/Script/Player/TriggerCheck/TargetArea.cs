using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArea : MonoBehaviour
{
    public Rigidbody2D RB;
    public List<Enemy> enemies = new List<Enemy>();


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if (enemies != null)
        // {
        //     foreach (var enemy in enemies)
        //     {
        //         int index = enemies.IndexOf(enemy);
        //         Check(enemy, index);
        //     }
        // }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            enemy.isTarget.SetActive(true);
            enemies.Add(enemy);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            enemy.isTarget.SetActive(false);
            enemies.Remove(enemy);
        }
    }

    void Check(Enemy enemy, int index)
    {
        if (index == 0)
        {
            Debug.Log("Check");
            enemy.isTarget.SetActive(true);
        }
        else
        {
            enemy.isTarget.SetActive(false);
        }
    }
}
