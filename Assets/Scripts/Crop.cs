using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Crop : MonoBehaviour
{
    public Tile tile;
    public bool fullGrown;
    public float growRate = 0.1f;
    public Tilemap tilemap;
    public TilemapRenderer render;
    public int points;
    public string PlantType;

    public void Spawn()
    {
        tilemap.tileAnchor = new Vector3(0.5f, 0.5f, -1.9f);
        tilemap.SetTile(GetPosition(), tile);
    }

    public void Despawn()
    {
        var position = Vector3Int.FloorToInt(transform.position);
        tilemap.SetTile(GetPosition(), null);
    }

    protected Vector3Int GetPosition()
    {
        return Vector3Int.FloorToInt(transform.position);
    }

    public abstract void OnTurn();

    public abstract void OnHarvest();
}