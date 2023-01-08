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

            //adds points to player score
            Debug.Log(crop.points);

            //list for adjacent tile iteration
            List<int> adj = new List<int>{
                -1,1
            };

            //iterating for adjacents on x axis
            foreach (int a in adj)
            {   
                position = new Vector3Int(position.x+a,position.y);
                //cheching if a crop is on tile
                if (cm.GetCrop(position, out crop))
                {
                    // calls onharvest to harvest plant
                    crop.OnHarvest();

                    //adds points to player score
                    Debug.Log(crop.points);
                }
            }

            //iterating for adjacents on y axis
            foreach (int a in adj)
            {   
                position = new Vector3Int(position.x,position.y+a);
                //cheching if a crop is on tile
                if (cm.GetCrop(position, out crop))
                {
                    // calls onharvest to harvest plant
                    crop.OnHarvest();

                    //adds points to player score
                    Debug.Log(crop.points);
                }
            }
        }
    }


  
}
