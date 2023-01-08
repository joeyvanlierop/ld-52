using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealCard : Card
{
    
    new void Start()
    {
        base.Start();
    }

    public override void ActionPerformed(Vector3Int position)
    {
        // transfers card to other player
        Debug.Log("stealTile");
    }

    protected override void SetMaterial(HighlightEffect hf, Vector3Int position)
    {
        lr.material = redMaterial;
    }
}
