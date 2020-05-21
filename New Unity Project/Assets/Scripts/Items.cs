using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Inventory/Item")]
public class Items : ScriptableObject
{    
    new public string name = "New Item" ;
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public Vector3 size; 

    public virtual void Use ()
    {
        //use the item 

        //something will happen 

        Debug.Log("using " + name);
        GearManager.instance.size = size; 

    }


    public virtual void RemoveAfterUse()
    {
        Inventory.instance.Remove(this); 

    }

}
