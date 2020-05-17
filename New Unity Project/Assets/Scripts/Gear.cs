using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "New Gear", menuName = "Inventory/Gear")]
 
public class Gear : Items
{
    public Vector3 gearsize; 
    
    public override void Use()
    {
        base.Use();

        GearManager.instance.used = true;
        GearManager.instance.Spawn(); 


    }



}

