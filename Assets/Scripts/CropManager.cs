using UnityEngine;

public class CropManager : MonoBehaviour
{
    public void OnTurn()
    {
        var cropObjects = GameObject.FindGameObjectsWithTag("Crop");
        foreach(GameObject cropObject in cropObjects)
        {
            var crop = cropObject.GetComponent<Crop>();
            crop.OnTurn();
        }
    }
}
