using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropManager : MonoBehaviour
{
    public Tile[] ownerTiles;
    public Tilemap ownerTilemap;
        
    private Dictionary<Vector3Int, Crop> crops = new();
    private Dictionary<Vector3Int, int> owners = new();
    
    public void OnTurn()
    {   
        if (crops.Count == 0) {
            return;
        }
        foreach(Crop crop in crops.Values)
        {
            crop.OnTurn();
        }
    }
    
    public void SetOwner(Vector3Int position, int playerIndex)
    {
        Debug.Log("DEBUG");
        owners.Add(position, playerIndex);
        ownerTilemap.SetTile(position, ownerTiles[playerIndex]);
    }

    public void AddCrop(Vector3Int position, GameObject cropObject)
    {
        var cropObj = Instantiate(cropObject, position, Quaternion.identity);
        var crop = cropObj.GetComponent<Crop>();
        var cropsTilesetObject = GameObject.FindGameObjectWithTag("Crops");
        cropsTilesetObject.transform.SetParent(GameObject.FindGameObjectWithTag("Grid").transform);
        cropsTilesetObject.transform.localPosition = new Vector3(0,0,0);
        crop.tilemap = cropsTilesetObject.GetComponent<Tilemap>();
        crop.render = cropsTilesetObject.GetComponent<TilemapRenderer>();
        crops.Add(position, cropObj.GetComponent<Crop>());

        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SetOwner(position, gm.currentPlayerIndex);
    }

    public void RemoveCrop(Vector3Int position)
    {
        if (!crops.TryGetValue(position, out var crop))
            return;
        Destroy(crop);
        crops.Remove(position);
    }

    public bool GetCrop(Vector3Int key, out Crop crop)
    {
        return crops.TryGetValue(key, out crop);
    }
}
