using UnityEngine;

public class FertilizerCard : Card
{
    private new void Start()
    {
        base.Start();
    }

    public override void ActionPerformed(Vector3Int position)
    {
        var cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        if (cm.GetCrop(position, out var crop))
        {
            crop.tilemap.tileAnchor = new Vector3(0.5f, 0.5f, 0);
            crop.render.sortingOrder = 1;
            crop.fullGrown = true;
        }
    }

    protected override bool IsValid(CropManager cm, Vector3Int position)
    {
        if (!cm.GetCrop(position, out var crop) || crop.fullGrown)
            return false;

        var gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (cm.GetOwner(position, out var owner) && owner != gm.currentPlayerIndex)
            return false;

        return true;
    }
}