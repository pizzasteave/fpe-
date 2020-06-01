using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    #region Singleton 
    public static PickUp instance;
    void Awake()
    {
        instance = this;
    }

    #endregion

    // Start is called before the first frame update
    public Items  item;

    public void Start()
    {
        if (this.CompareTag("Gear"))
        {
            item.size = this.transform.localScale; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2);  // make limits 
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Player")      //check if player inside the sphere
            {
                if (Input.GetMouseButtonDown(0))
               {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    //Debug.DrawRay(ray.origin, ray.direction * 5f);

                    if (Physics.Raycast(ray, out hit))
                    { 
                        
                        Debug.Log(hit.transform.name ) ;
                        if (hit.transform.name == this.name)      //if mouse on the item 
                        {
                           

                            bool wasPickedUp = Inventory.instance.Add(item);   

                            if (wasPickedUp)
                            {
                                Debug.Log("item picked =  " + item.name);        //if item picked 
                                Destroy(transform.parent.gameObject);
                               
                                
                            }
                        }

                    }



                }

            }

            i++;                                       //if player not detected 
           
          
        }

       
    }


   
}

   
    

