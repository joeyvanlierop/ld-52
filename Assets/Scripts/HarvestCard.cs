using System.Collections.Generic;
using UnityEngine;

public class HarvestCard : Card
{
    private new void Start()
    {
        base.Start();
    }

    public override void ActionPerformed(Vector3Int position)
    {
        //getting crop manaager
        var cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();

        //cheching if a crop is on tile
        Crop crop;
        Crop CropAdj;
        if (cm.GetCrop(position, out crop))
        {
            // calls onharvest to harvest plant
            crop.OnHarvest();

            //list for adjacent tile iteration
            var adj = new List<int>
            {
                -1, 1
            };

            //iterating for adjacents on x axis
            foreach (var a in adj)
            {
                var newPosition = new Vector3Int(position.x + a, position.y);
                //cheching if a crop is on tile
                if (cm.GetCrop(newPosition, out CropAdj))
                    // calls onharvest to harvest plant if adjacent plant is same plant type
                    if (CropAdj.PlantType == crop.PlantType)
                    {
                        CropAdj.OnHarvest();
                    }
            }

            //iterating for adjacents on y axis
            foreach (var a in adj)
            {
                var newPosition = new Vector3Int(position.x, position.y + a);
                //cheching if a crop is on tile
                if (cm.GetCrop(newPosition, out CropAdj))
                    // calls onharvest to harvest plant if adjacent plant is same plant type
                    if (CropAdj.PlantType == crop.PlantType)
                    {
                        CropAdj.OnHarvest();
                    }
                    
            }
        }
    }

    protected override bool IsValid(CropManager cm, Vector3Int position)
    {
        if (!cm.GetCrop(position, out var crop) || !crop.fullGrown)
            return false;

        var gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (cm.GetOwner(position, out var owner) && owner != gm.currentPlayerIndex)
            return false;

        return true;
    }
}