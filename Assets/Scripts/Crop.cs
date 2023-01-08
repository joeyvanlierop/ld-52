using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Crop : MonoBehaviour
{
    public Tile tile;
    public bool fullGrown = false;
    public float growRate = 0.1f;
    public Tilemap tilemap;
    public TilemapRenderer render;

    
    // Start is called before the first frame update
    void Start()
    {
        tilemap.tileAnchor = new Vector3(0.5f, 0.5f, -1.9f);
        var position = Vector3Int.FloorToInt(transform.position);
        tilemap.SetTile(position, tile);
        tilemap.SetColor(position, Color.red);
    }

    public abstract void OnTurn();
    
    public abstract void OnHarvest();
}
