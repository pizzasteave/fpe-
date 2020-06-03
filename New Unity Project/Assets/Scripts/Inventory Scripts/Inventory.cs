using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton 
    public static Inventory instance;
     void Awake()
    {
        if (instance != null )
        {
            Debug.LogWarning("more than one instance of inventory found");
            return; 
        }
        instance = this; 
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack; 

    public List<Items> items = new List<Items>();
    public int space = 20; 
    public    bool Add (Items item )
    {
        if (!item.isDefaultItem) {            //if default item 
            if (items.Count >= space )        // m3abiya 
            {
                Debug.Log("not enough space");
                return false ; 
            }
        items.Add(item);
            if (onItemChangedCallBack != null) 
            onItemChangedCallBack.Invoke(); 
        }
        return true;                    // if added 
    }

    internal void Remove(GearManager gearManager)
    {
        throw new NotImplementedException();
    }

    public void Remove (Items item )
    {

        items.Remove(item);
        if (onItemChangedCallBack != null) 
        onItemChangedCallBack.Invoke();
    }
}
