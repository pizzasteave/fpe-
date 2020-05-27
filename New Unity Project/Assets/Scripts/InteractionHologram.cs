using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InteractionHologram : MonoBehaviour
{
   
    
    #region Singleton 
    public static InteractionHologram instance;
    void Awake()
    {
        instance = this;
    }

    #endregion

    public bool playerdetected; 
    public GameObject hologramPrefab;
    public GameObject newHologram;
    public GameObject newGear;
    public GameObject GearPrefab; 
    public Vector3 size;
    public bool gearDetectedForPickUp; 
    // Start is called before the first frame update


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        size = GearManager.instance.size;

        bool used = GearManager.instance.used;
        //GameObject[] gearPrefab = GameObject.FindGameObjectsWithTag("Gear");


        if (CheckCloseToHologram("Player", 3f) && used == true)
        {

            Debug.Log("player detected");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           // RaycastHit[] hits;
            RaycastHit hit; 
           // hits = Physics.RaycastAll(ray.origin, ray.direction, 100.0F);

           /* for (int i = 0; i < hits.Length; i++)
            { if (hits[i].transform.name == "Gear" )   {

                    gearDetectedForPickUp = true;
                    Debug.Log("sssssssssssssssssss"); 
                
                }
            
            
            } */

                if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * 5);
                if (hit.transform.name == this.name)
                {                                                             //if mouse on the item 
                    Debug.Log(this.name);

                    if (newHologram == null  && newGear == null )
                    {

                        newHologram = Instantiate(hologramPrefab) as GameObject;
                        newHologram.transform.localScale = size; 
                        newHologram.transform.position = this.transform.position;
                        newHologram.transform.rotation = this.transform.rotation;

                        Debug.Log(hit.transform.name);

                    }

                    if ( Input.GetMouseButtonDown(1) && newGear==null)

                    {
                        DestroyHologram(newHologram);
                  
                        newGear = Instantiate(GearPrefab) as GameObject;
                        newGear.transform.localScale = size;
                        newGear.transform.position = this.transform.position;
                        newHologram.transform.rotation = this.transform.rotation;
                        DestroyHologram(GearManager.instance.newgear); 
                    }


                }
                else if (hit.transform == null || hit.transform.name != this.name  )  {
                    
                    
                   Debug.Log("out of vision ");
                    DestroyHologram(newHologram);
                }


            }
        }

        else
        {
            DestroyHologram(newHologram);
            Debug.Log("destroyed out of range ");

        }
            
    }

    public bool CheckCloseToHologram (string tag, float minimumDistance)
{
    GameObject[] goWithTag = GameObject.FindGameObjectsWithTag(tag);

    for (int i = 0; i < goWithTag.Length; ++i)
    {
        if (Vector3.Distance(transform.position, goWithTag[i].transform.position) <= minimumDistance)
            return true;
    }

    return false;
}


    public void DestroyHologram(GameObject Hologram)
    {
        Destroy(Hologram);
    }

}
