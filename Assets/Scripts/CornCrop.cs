using UnityEngine;

public class CornCrop : Crop
{
    public override void OnTurn()
    {
        if (tilemap.tileAnchor.z > -1) return;

        tilemap.tileAnchor = new Vector3(tilemap.tileAnchor.x - 0.1f, tilemap.tileAnchor.y - 0.1f, tilemap.tileAnchor.z + growRate);
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