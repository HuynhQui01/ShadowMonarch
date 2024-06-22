using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    public GameObject dashEffectPrefab;
    public float delay = 1f;
    float delta = 0f;

    PlayerController playerController;
    SpriteRenderer spriteRenderer;
    public float destroyTime = 0.1f;
    public Color color;
    public Material material = null;

    void Start(){
        playerController = GetComponent<PlayerController>();
    }

    void FixedUpdate(){
        if(delta > 0){ delta -= Time.deltaTime; }
        else{ delta = delay; CreateEffect();}
    }

    public void CreateEffect(){
        GameObject effect = Instantiate(dashEffectPrefab, transform.position, transform.rotation);

        effect.transform.localScale = playerController.transform.localScale;
        Destroy(effect, destroyTime);

        spriteRenderer = effect.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = playerController.spriteRenderer.sprite;
        spriteRenderer.color = color;
        if(material != null) spriteRenderer.material = material;
    }
    

}
