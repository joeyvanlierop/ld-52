using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotageCard : Card
{
    
    new void Start()
    {
        base.Start();
    }

    public override void ActionPerformed(Vector3Int position)
    {
        CropManager cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        cm.RemoveCrop(position);
    }

    protected override bool IsValid(CropManager cm, Vector3Int position)
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (cm.GetOwner(position, out var owner) && owner != gm.currentPlayerIndex)
            return true;

        return false;
    }
}
