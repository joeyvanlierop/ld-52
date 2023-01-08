using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestCard : Card
{
    new void Start()
    {
        base.Start();
    }

    public override void ActionPerformed(Vector3Int position)
    {
        //getting crop manaager
        CropManager cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();

        //cheching if a crop is on tile
        Crop crop;
        if (cm.GetCrop(position, out crop))
        {
            // calls onharvest to harvest plant
            crop.OnHarvest();

            //list for adjacent tile iteration
            List<int> adj = new List<int>
            {
                -1, 1
            };

            //iterating for adjacents on x axis
            foreach (int a in adj)
            {
                var newPosition = new Vector3Int(position.x + a, position.y);
                //cheching if a crop is on tile
                if (cm.GetCrop(newPosition, out crop))
                {
                    // calls onharvest to harvest plant
                    crop.OnHarvest();
                }
            }

            //iterating for adjacents on y axis
            foreach (int a in adj)
            {
                var newPosition = new Vector3Int(position.x, position.y + a);
                //cheching if a crop is on tile
                if (cm.GetCrop(newPosition, out crop))
                {
                    // calls onharvest to harvest plant
                    crop.OnHarvest();
                }
            }
        }
    }

    public override bool IsValid(CropManager cm, Vector3Int position)
    {
        if (!cm.GetCrop(position, out var crop) || !crop.fullGrown)
            return false;
        
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (cm.GetOwner(position, out var owner) && owner != gm.currentPlayerIndex)
            return false;

        return true;
    }
}