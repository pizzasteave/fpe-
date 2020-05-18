using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InteractionHologram : MonoBehaviour
{

    public bool playerdetected; 
    public GameObject hologramPrefab;
    public GameObject newHologram;
    public Vector3 size; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        size = GearManager.instance.size;

        bool used  = GearManager.instance.used;
        
        if (CheckCloseToHologram("Player", 3f) && used == true)
        {

            Debug.Log("player detected");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * 5);
                if (hit.transform.name == this.name)
                {     //if mouse on the item 
                    Debug.Log(this.name);

                    if (newHologram == null)
                    {

                        newHologram = Instantiate(hologramPrefab) as GameObject;
                        newHologram.transform.localScale = size; 
                        newHologram.transform.position = this.transform.position;
                        newHologram.transform.rotation = this.transform.rotation;

                        Debug.Log(hit.transform.name);

                    }

                }
                else if (hit.transform == null || hit.transform.name != this.name )  { Debug.Log("out of vision ");
                    Destroy(newHologram);
                }


            }
        }

        else
        {
            Destroy(newHologram);
            Debug.Log("destroyed out of range ");

        }
            
    }

     bool CheckCloseToHologram (string tag, float minimumDistance)
{
    GameObject[] goWithTag = GameObject.FindGameObjectsWithTag(tag);

    for (int i = 0; i < goWithTag.Length; ++i)
    {
        if (Vector3.Distance(transform.position, goWithTag[i].transform.position) <= minimumDistance)
            return true;
    }

    return false;
}

}
