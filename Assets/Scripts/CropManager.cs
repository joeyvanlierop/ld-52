using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public void AddCrop(Vector3Int position, GameObject cropObject)
    {
        Instantiate(cropObject, position, Quaternion.identity);
        crops.Add(position, cropObject.GetComponent<Crop>());
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
