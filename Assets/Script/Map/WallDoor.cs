using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallDoor : MonoBehaviour
{
    Tilemap tilemap;
    SpriteRenderer spriteRenderer;
    public TilemapCollider2D tilemapCollider2D;
    void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        tilemapCollider2D = GetComponent<TilemapCollider2D>();
        gameObject.SetActive(false);
    }

    

    

}
