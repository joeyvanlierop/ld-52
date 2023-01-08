using UnityEngine;

public class CornCrop : Crop
{
    public override void OnTurn()
    {
        Debug.Log("I am a corn crop");
    }

    public override void OnHarvest()
    {
        Debug.Log("Harvest");
    }
}
