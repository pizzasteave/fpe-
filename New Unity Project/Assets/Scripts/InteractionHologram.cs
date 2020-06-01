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
   // public Items gearOldGear; 
    private Collider collider; 


  [SerializeField]
    private LayerMask layermask; 
    // Start is called before the first frame update


    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        size = GearManager.instance.size;
        //gearOldGear = GearManager.instance.gearOldGear; 

        bool used = GearManager.instance.used;
        //GameObject[] gearPrefab = GameObject.FindGameObjectsWithTag("Gear");


        if (CheckCloseToHologram("Player", 3f) && used == true)              // if player on range 
        {
        
            collider.enabled = true;
            Debug.Log("player detected");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var multipleHits = Physics.RaycastAll(ray,5f, layermask);

            // RaycastHit[] hits;
            // RaycastHit hit;
            // hits = Physics.RaycastAll(ray.origin, ray.direction, 100.0F);

            /* for (int i = 0; i < hits.Length; i++)
             { if (hits[i].transform.name == "Gear" )   {

                     gearDetectedForPickUp = true;
                     Debug.Log("sssssssssssssssssss"); 

                 }


             } */

            foreach (var hit in multipleHits)
            {
                Debug.DrawRay(ray.origin, ray.direction * 5);
                
                if (hit.transform.tag == "SpawnGearPoint" && GearManager.instance.newgear != null )           // if player vision point on the SpawnGearObject
                {
                    if (newHologram == null && newGear == null)                 //if no hologram already true aka we need 1 hologram on the scene 
                                                                                //if no newGear localy arround the spawngearPoint aka to stop hologram from spawning if we got 1 gear spawn 
                    {

                        newHologram = Instantiate(hologramPrefab) as GameObject;        //
                        newHologram.transform.localScale = size;
                        newHologram.transform.position = this.transform.position;
                        newHologram.transform.rotation = this.transform.rotation;

                        Debug.Log(hit.transform.name);

                    }

                    if (Input.GetMouseButtonDown(1) && newGear == null)

                    {
                        DestroyHologram(newHologram);

                        newGear = Instantiate(GearPrefab) as GameObject;
                        newGear.transform.localScale = size;
                        newGear.transform.position = this.transform.position;
                        PickUp.instance.item = GearManager.instance.currentGear[GearManager.instance.slotIndex]; 

                        newHologram.transform.rotation = this.transform.rotation;
                        DestroyHologram(GearManager.instance.newgear);
                        GearManager.instance.currentGear[GearManager.instance.slotIndex] = null;   //remove this gear from the currnet gears (no old item because it is used)


                    }

                  

                }

                else if (hit.transform == null || hit.transform.name != this.name)
                {


                    Debug.Log("out of vision ");
                    DestroyHologram(newHologram);
                }

                if (Input.GetMouseButtonDown(0)  && hit.transform.name == "GearI")
                {                    
                    collider.enabled = false;
                   // DestroyHologram(newGear); 
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
