using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightEffect : MonoBehaviour
{
    public bool active = true;
    public Tile highlightTile;
    public Tile blacklistTile;
    public Vector3Int offset = Vector3Int.zero;
    private CropManager cropManager;
    private Tilemap highlightTileMap;

    private void Start()
    {
        highlightTileMap = GameObject.FindGameObjectWithTag("Highlight").GetComponent<Tilemap>();
        cropManager = GetComponent<CropManager>();
    }

    private void Update()
    {
        if (!active)
            return;

        highlightTileMap.ClearAllTiles();

        var highlightPosition = GetHighlightPosition();

        if (cropManager.IsValidTile(highlightPosition))
            highlightTileMap.SetTile(highlightPosition, highlightTile);
        else
            highlightTileMap.SetTile(highlightPosition, blacklistTile);
    }

    public Vector3Int GetHighlightPosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var highlightPosition = highlightTileMap.WorldToCell(mousePosition);
        highlightPosition += offset;
        return highlightPosition;
    }
}