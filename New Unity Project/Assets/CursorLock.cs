using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{

    public GameObject inventoryUI; 
    public Inventory inventory; 
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance; 
    }

    // Update is called once per frame
    void Update()
    { bool isitactive = inventoryUI.activeSelf; 
       if (isitactive == false )
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;


        }
        else
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        

        



    }
}
