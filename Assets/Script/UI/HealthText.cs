using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public float timeToLive = 0.5f;
    public float floatSpeed = 300f;
    public Vector3 floatDirection = new Vector3(0, 1, 0);
    public TextMeshProUGUI textMesh;
    RectTransform rectTransform;
    float timeElapsed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        rectTransform.position += floatDirection * floatSpeed *Time.deltaTime;
        if(timeElapsed > timeToLive){
            Destroy(gameObject);
        }
    }

    public void SetText(float damage){
        textMesh.text = damage.ToString();
    }
}
