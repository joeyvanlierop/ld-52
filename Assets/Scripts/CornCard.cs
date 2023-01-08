using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornCard : Card
{
    public GameObject cornCrop;
    
    new void Start()
    {
        base.Start();
    }

    public override void ActionPerformed(Vector3Int position)
    {
        CropManager cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        cm.AddCrop(position, cornCrop);
    }
}
