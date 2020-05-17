using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InteractionHologram : MonoBehaviour
{

    public bool playerdetected; 
    public GameObject hologramPrefab;
    public GameObject newHologram; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (playerdetected == true)
        {
            Debug.Log("player detected");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3f))
            {
                Debug.DrawRay(ray.origin, ray.direction * 5);
                if (hit.transform.name == this.name)
                {     //if mouse on the item 
                    Debug.Log(this.name);

                    if (newHologram == null)
                    {

                        newHologram = Instantiate(hologramPrefab) as GameObject;

                        newHologram.transform.position = this.transform.position;
                        newHologram.transform.rotation = this.transform.rotation;

                        Debug.Log(hit.transform.name);

                    }

                }


            }

        }
        else
        {
            Destroy(newHologram);
            Debug.Log("destroyed out of vision");

        }
            
    }


             






    private void OnTriggerEnter(Collider other)
    {
        playerdetected = true; 

    }


    private void OnTriggerExit(Collider other)
    {
        playerdetected = false; 
    }

}
