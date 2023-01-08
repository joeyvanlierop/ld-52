using UnityEngine;

public class TerraformCard : Card
{
    new void Start()
    {
        base.Start();
    }

    public override void ActionPerformed(Vector3Int position)
    {
        CropManager cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        cm.RemoveObstacle(position);
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cm.SetOwner(position, gm.currentPlayerIndex);
    }
    
    protected override bool IsValid(CropManager cm, Vector3Int position)
    {
        return cm.IsObstacle(position);
    }
}
