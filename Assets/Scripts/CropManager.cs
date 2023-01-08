using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropManager : MonoBehaviour
{
    public Tile[] ownerTiles;
    public Tilemap ownerTilemap;
    public Tilemap[] groundTilemaps;
    public Tilemap[] obstacleTilemaps;
    public Tile[] blacklistedTiles;
        
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
        owners[position] = playerIndex;
        ownerTilemap.SetTile(position, ownerTiles[playerIndex]);
    }

    public void AddCrop(Vector3Int position, GameObject cropObject)
    {
        Debug.Log($"{position.x}, {position.y}, {position.z}");
        var cropObj = Instantiate(cropObject, position, Quaternion.identity);
        var crop = cropObj.GetComponent<Crop>();
        var cropsTilesetObject = Instantiate(GameObject.FindGameObjectWithTag("Crops"));
        cropsTilesetObject.transform.SetParent(GameObject.FindGameObjectWithTag("Grid").transform);
        cropsTilesetObject.transform.localPosition = new Vector3(0,0,0);
        crop.tilemap = cropsTilesetObject.GetComponent<Tilemap>();
        crop.render = cropsTilesetObject.GetComponent<TilemapRenderer>();
        crop.Spawn();
        crops.Add(position, crop);

        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SetOwner(position, gm.currentPlayerIndex);
    }

    public void RemoveCrop(Vector3Int position)
    {
        if (!crops.TryGetValue(position, out var crop))
            return;
        crop.Despawn();
        crops.Remove(position);
    }

    public void HarvestCrop(Vector3Int position) {
        GetCrop(position, out Crop crop);
        var points = crop.points;
        GetOwner(position, out var owner);
        RemoveCrop(position);
        NotifyHarvest(points, owner);
    }


    public void NotifyHarvest(float points, int owner) {
        GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>().NotifyHarvest(points, owner);
    }


    public bool GetCrop(Vector3Int key, out Crop crop)
    {
        return crops.TryGetValue(key, out crop);
    }
    
    public bool GetOwner(Vector3Int key, out int owner)
    {
        return owners.TryGetValue(key, out owner);
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

    public bool IsWaterTile(Vector3Int position)
    {
        foreach (var tilemap in groundTilemaps)
        {
            //blacklisted tiles are the water ones
            if (blacklistedTiles.Contains(tilemap.GetTile(position)))
                return true;
        }

        return false;
    }

    public bool IsObstacle(Vector3Int position)
    {
        foreach (var tilemap in obstacleTilemaps)
        {
            if (tilemap.GetTile(position))
                return true;
        }

        return false;
    }
    
    public void RemoveObstacle(Vector3Int position)
    {
        foreach (var tilemap in obstacleTilemaps)
            tilemap.SetTile(position, null);
    }
}
