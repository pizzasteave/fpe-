using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public GameObject inventoryUI; 
    public Transform itemparents; 
    Inventory inventory;
    InventorySlot[] slots;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
        slots = itemparents.GetComponentsInChildren<InventorySlot>();  // n3abiw fel slots with inventory slots 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") ) {

            inventoryUI.SetActive(!inventoryUI.activeSelf); 

        }
        
    }



    void UpdateUI()
    {
        for (int i=0;i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItemToTheInventory(inventory.items[i]);

            }
            else

                slots[i].ClearSlot(); 
        }
         

    }


}
