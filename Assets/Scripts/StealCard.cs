using UnityEngine;

public class StealCard : Card
{
    private new void Start()
    {
        base.Start();
    }

    public override void ActionPerformed(Vector3Int position)
    {
        var cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        var gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cm.SetOwner(position, gm.currentPlayerIndex);
    }

    public override bool IsValid(CropManager cm, Vector3Int position)
    {
        var gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (cm.GetOwner(position, out var owner) && owner != gm.currentPlayerIndex)
            return true;

        return false;
    }
}