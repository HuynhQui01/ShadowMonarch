using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAttributePanel : MonoBehaviour
{
    
    public Player player;
    public TMP_Text characterName;
    public TMP_Text attributes;

    void Start(){
        player = GetComponentInParent<Player>();
    }

    void Update(){
        // characterName.text = player.characterName;
        attributes.text = "Level: \t" + player.Level + "\n" + "Experiences: \t" + player.Experience + "/" + player.MaxExperience + "\n" 
                            + "Max health: \t" + player.CurrentHealth + "/" + player.MaxHealth + "\n"
                            + "Max armor: \t" + player.CurrentArmor + "/" + player.MaxArmor + "\n"
                            + "Damage: \t" + player.Damage + "\n" + "Defence: \t" + player.Defence;
                            // Debug.Log(player.Damage);
    }

    

    
}
