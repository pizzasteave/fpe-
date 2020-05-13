using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;  
    Items item; 
   public void AddItemToTheInventory(Items newItem)
    {
        item = newItem;


        icon.sprite = item.icon;
        icon.enabled = true;


        removeButton.interactable = true; 
        

    }

    public void ClearSlot ()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;


        removeButton.interactable = false;
    }


    public void OnRemoveButton ()
    {

        Inventory.instance.Remove(item); 

    }


    public void OnUseButon ()
    {
        if (item != null )
        {

            item.Use(); 

        }


    }
}
