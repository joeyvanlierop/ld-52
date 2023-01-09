using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightEffect : MonoBehaviour
{
    private CropManager cropManager;
    private Tilemap highlightTileMap;

  public bool active = false;
  public Card draggedCard = null;
  public Tile highlightTile;
  public Tile blacklistTile;
  public Vector3Int offset = Vector3Int.zero;
  public bool isValidTile = false;
  public bool hovering = false;
    private void Start()
    {
        
    }

    public void StartManager() {
      highlightTileMap = GameObject.FindGameObjectWithTag("Highlight").GetComponent<Tilemap>();
      cropManager = GetComponent<CropManager>();
    }


    private void Update()
    {
        if (!active)
            return;

        highlightTileMap.ClearAllTiles();



    highlightTileMap.ClearAllTiles();
    var highlightPosition = GetHighlightPosition();
    

    if (isValidTile)
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
}
