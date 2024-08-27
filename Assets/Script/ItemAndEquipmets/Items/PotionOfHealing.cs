using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionOfHealing : MonoBehaviour
{
    float heal = 20f;

    void Awake(){

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if(player.CurrentHealth < player.MaxHealth){
                player.CurrentHealth += heal;
                player.healthbars.SetHealth(player.CurrentHealth);
                if(player.CurrentHealth >= player.MaxHealth){
                    player.CurrentHealth = player.MaxHealth;
                }
                Destroy(gameObject);
            }
        }
    }
}
