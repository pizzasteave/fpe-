using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public Items item; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {





            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == this.name)
                {

                   
                    bool wasPickedUp = Inventory.instance.Add(item);

                    if (wasPickedUp)
                    {
                        Debug.Log("item picked =  " + item.name);
                        Destroy(gameObject);
                    }
                }
               
                }
            




        }
    }
}
