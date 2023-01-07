using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Crop : MonoBehaviour
{

    public int x;
    public int y;
    public Tile tile;
    public int[] growTime;
    
    // Start is called before the first frame update
    void Start()
    {
        var tilemap = GameObject.FindGameObjectWithTag("Crops").GetComponent<Tilemap>();
        tilemap.SetTile(new Vector3Int(x, y, 0), tile);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Test");
    }
}
