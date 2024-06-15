using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitEffect : MonoBehaviour
{
    public GameObject onHitPrefab;
    public float delay = 1f;
    float delta = 0f;


    public float destroyTime = 0.25f;
    EnemyController enemyController;

    SpriteRenderer spriteRenderer;
    // public Color color;


    
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(delta > 0){ delta -= Time.deltaTime; }
        else{ delta = delay; CreateEffect();}
    }

    void CreateEffect(){
        GameObject effect = Instantiate(onHitPrefab, transform.position, transform.rotation);

        effect.transform.localScale = new Vector3(enemyController.transform.localScale.x -0.5f, enemyController.transform.localScale.y -0.5f);
        Destroy(effect, destroyTime);
        spriteRenderer = effect.GetComponent<SpriteRenderer>();

        // spriteRenderer.color = color;
    }
}
