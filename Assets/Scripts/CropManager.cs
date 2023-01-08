using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropManager : MonoBehaviour
{
    private Dictionary<Vector3Int, Crop> crops;
    
    public void OnTurn()
    {
        var cropObjects = GameObject.FindGameObjectsWithTag("Crop");
        foreach(GameObject cropObject in cropObjects)
        {
            var crop = cropObject.GetComponent<Crop>();
            crop.OnTurn();
        }
    }

    public void AddCrop(Vector3Int position, GameObject cropObject, GameObject tileStuff)
    {
        var cropObj = Instantiate(cropObject, position, Quaternion.identity);
        var crop = cropObj.GetComponent<Crop>();
        tileStuff.transform.SetParent(GameObject.FindGameObjectWithTag("Grid").transform);
        tileStuff.transform.localPosition = new Vector3(0,0,0);
        crop.tilemap = tileStuff.GetComponent<Tilemap>();
        crop.render = tileStuff.GetComponent<TilemapRenderer>();
        crops.Add(position, crop);
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
