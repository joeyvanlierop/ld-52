using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Crop : MonoBehaviour
{
    public Tile tile;
    
    // Start is called before the first frame update
    void Start()
    {
        var tilemap = GameObject.FindGameObjectWithTag("Crops").GetComponent<Tilemap>();
        var position = Vector3Int.FloorToInt(transform.position);
        tilemap.SetTile(position, tile);
        tilemap.SetColor(position, Color.red);
    }

    public abstract void OnTurn();
}
