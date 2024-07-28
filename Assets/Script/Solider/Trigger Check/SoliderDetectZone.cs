using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderDetectZone : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Enemy")
        {
            if (!collider2D.GetComponent<Enemy>().isDead)
            {
                enemies.RemoveAll(item => item == null);

                enemies.RemoveAll(item => item == null);
                enemies.Add(collider2D.GetComponent<Enemy>());
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Enemy")
        {
            if (!collider2D.GetComponent<Enemy>().isDead)
            {
                enemies.Remove(collider2D.GetComponent<Enemy>());
                enemies.Add(null);
            }
        }
    }
}
