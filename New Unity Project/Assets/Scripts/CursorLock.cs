using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    #region Singleton 
    public static CursorLock instance;
    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject inventoryUI; 
    public Inventory inventory;
    public bool usingST; 
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance; 
    }

    // Update is called once per frame
    void Update()
    { bool isitactive = inventoryUI.activeSelf; 
       if (isitactive == true || usingST  )
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;


        }
        

        



    }
}
