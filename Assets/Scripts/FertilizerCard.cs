using UnityEngine;

public class FertilizerCard : Card
{
    new void Start()
    {
        base.Start();
    }

    public override void ActionPerformed(Vector3Int position)
    {
        CropManager cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        if (cm.GetCrop(position, out var crop))
        {
            crop.tilemap.tileAnchor = new Vector3(0.5f, 0.5f, 0);
            crop.render.sortingOrder = 1;
            crop.fullGrown = true;
        }
    }
    
    protected override bool IsValid(CropManager cm, Vector3Int position)
    {
        if (!cm.IsValidTile(position))
            return false;

        if (cm.GetCrop(position, out var crop))
            return false;

        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (cm.GetOwner(position, out var owner) && owner != gm.currentPlayerIndex)
            return false;

        return true;
    }
}
