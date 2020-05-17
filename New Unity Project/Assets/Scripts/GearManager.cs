using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GearManager : MonoBehaviour
{
    public GameObject gearprefab; 
    
    GameObject newgear; 
    public bool used;
    public GameObject player;
   public Transform spawn; 

   #region Singleton 
    public static GearManager instance;
    void Awake()
    {
      
     
        instance = this;
    }

    #endregion


   
    
    
    void Update()
    {
        if (used == true)
        {

            
            newgear.transform.position = spawn.position;
            newgear.transform.rotation = spawn.rotation;
        } 

        // gear = GameObject.Find("Gear");
        /* if  (Input.GetMouseButtonDown(1))
         {


             Vector3 mouse = Input.mousePosition;
             newgear.transform.position = mouse;


         }*/


    }


    public void Spawn()
    {
        if (used == true)
        {

            newgear = Instantiate(gearprefab) as GameObject;
            // transform.localScale = player.transform.localScale;
            Physics.IgnoreCollision(newgear.GetComponent<Collider>(),player.GetComponent<Collider>()) ; 
            Update();
           

            Debug.Log("spaw");

        }

    }

}