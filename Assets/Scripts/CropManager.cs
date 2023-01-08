using System;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    public 
    
    public void OnTurn()
    {
        var cropObjects = GameObject.FindGameObjectsWithTag("Crop");
        foreach(GameObject cropObject in cropObjects)
        {
            var crop = cropObject.GetComponent<Crop>();
            crop.OnTurn();
        }
    }

    public bool HasCrop(Vector3Int position)
    {
        throw new NotImplementedException();
    }
}
