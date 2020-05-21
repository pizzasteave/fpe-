using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "New Gear", menuName = "Inventory/Gear")]
 
public class Gear : Items
{

    public Geartypes geartypes;

    public override void Use()
    {
        base.Use();
        GearManager.instance.SameGear(this);
        GearManager.instance.used = true;    
        Debug.Log("here");
        RemoveAfterUse();
        GearManager.instance.Spawn();

    }
   
}

public enum Geartypes { Gear1, Gear2 };

