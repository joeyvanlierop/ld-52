using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightEffect : MonoBehaviour
{
  Tilemap highlightTileMap;

  public bool enabled = true;
  public Tile highlightTile;
  public Tile blacklistTile;
  public Vector3Int offset = Vector3Int.zero;
  public Tilemap[] groundTilemaps;
  public Tilemap[] obstacleTilemaps;
  public Tile[] blacklistedTiles;
  public GameObject cornCrop;

  void Start()
  {
    highlightTileMap = GameObject.FindGameObjectWithTag("Highlight").GetComponent<Tilemap>();
  }

  void Update()
  {
    if (!enabled)
      return;

    highlightTileMap.ClearAllTiles();

    var highlightPosition = GetHighlightPosition();

    if (IsValidTile(highlightPosition))
      highlightTileMap.SetTile(highlightPosition, highlightTile);
    else
      highlightTileMap.SetTile(highlightPosition, blacklistTile);
  }

  public Vector3Int GetHighlightPosition()
  {
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3Int highlightPosition = highlightTileMap.WorldToCell(mousePosition);
    highlightPosition += offset;
    return highlightPosition;
  }

  public bool IsValidTile(Vector3Int position)
  {
    foreach (var tilemap in groundTilemaps)
    {
      if (!tilemap.GetTile(position))
        return false;
      if (blacklistedTiles.Contains(tilemap.GetTile(position)))
        return false;
    }

    foreach (var tilemap in obstacleTilemaps)
    {
      if (tilemap.GetTile(position))
        return false;
    }

    return true;
  }
}
