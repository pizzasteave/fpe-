using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    public GameObject gearprefab; 
    public GameObject gear;
    GameObject newgear; 
    public bool used;
    public Camera cam; 

    #region Singleton 
    public static GearManager instance;
    void Awake()
    {
      
     
        instance = this;
    }

    #endregion


     public void Spawn ( )
    {
        if (used == true)
        {

            newgear = Instantiate(gearprefab) as GameObject;
           Vector3 camposition = cam.transform.position;
            newgear.transform.position =  new Vector3(camposition.x , camposition.y, camposition.z - 5f );
           
            
            Debug.Log("spaw");

        }

    }
    
    
    
    void Update()
    {

        // gear = GameObject.Find("Gear");
        if  (Input.GetMouseButtonDown(1))
        {


            Vector3 mouse = Input.mousePosition;
            newgear.transform.position = mouse;


        }


    }
}