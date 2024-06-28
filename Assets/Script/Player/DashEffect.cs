using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    public GameObject dashEffectPrefab;
    public float delay = 1f;
    float delta = 0f;

    Player player;
    SpriteRenderer spriteRenderer;
    public float destroyTime = 0.1f;
    public Color color;
    public Material material = null;

    void Start(){
        player = GetComponent<Player>();
        GameObject effect = Instantiate(dashEffectPrefab, transform.position, transform.rotation);

    }

    void FixedUpdate(){
        if(delta > 0){ delta -= Time.deltaTime; }
        else{ delta = delay; CreateEffect();}
    }

    public void CreateEffect(){
        GameObject effect = Instantiate(dashEffectPrefab, transform.position, transform.rotation);

        effect.transform.localScale = player.transform.localScale;
        Destroy(effect, destroyTime);

        spriteRenderer = effect.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = player.spriteRenderer.sprite;
        spriteRenderer.color = color;
        if(material != null) spriteRenderer.material = material;
    }
    

}
