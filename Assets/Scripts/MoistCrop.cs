using UnityEngine;

public class MoistCrop : Crop
{
    public void Start()
    {
        PlantType = "moist";
    }
    
    public override void OnTurn()
    {
        if (tilemap.tileAnchor.z > -1) return;

        tilemap.tileAnchor = new Vector3(0.5f, 0.5f, tilemap.tileAnchor.z + growRate);
        if (tilemap.tileAnchor.z > -1)
        {
            tilemap.tileAnchor = new Vector3(0.5f, 0.5f, 0);
            render.sortingOrder = 1;
            fullGrown = true;
        }
    }

    public override void OnHarvest()
    {
        var cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        cm.HarvestCrop(GetPosition());
    }
}