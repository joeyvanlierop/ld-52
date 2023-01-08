using UnityEngine;

public class TerraformCard : Card
{
    private new void Start()
    {
        base.Start();
    }

    public override void ActionPerformed(Vector3Int position)
    {
        var cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        cm.RemoveObstacle(position);
        var gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cm.SetOwner(position, gm.currentPlayerIndex);
    }

    public override bool IsValid(CropManager cm, Vector3Int position)
    {
        return cm.IsObstacle(position);
    }
}