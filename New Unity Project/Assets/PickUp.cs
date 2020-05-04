using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public Items item;
    public bool playerdetected;
    

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



                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.name == this.name)      //if mouse on the item 
                        {


                            bool wasPickedUp = Inventory.instance.Add(item);   

                            if (wasPickedUp)
                            {
                                Debug.Log("item picked =  " + item.name);     //if item picked 
                                Destroy(gameObject);
                            }
                        }

                    }



                }

            }

            i++;                                       //if player not detected 
           
          
        }

       
    }


   
}

   
    

