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
        var position = transform.position;
        tilemap.SetTile(new Vector3Int((int)position.x, (int)position.y, 0), tile);
    }

    public abstract void OnTurn();
}
