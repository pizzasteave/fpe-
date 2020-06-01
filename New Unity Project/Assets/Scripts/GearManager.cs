
using JetBrains.Annotations;
using UnityEngine;


public class GearManager : MonoBehaviour
{
    public GameObject gearprefab;
    public Inventory inventory; 
    public GameObject newgear; 
    public bool used;
    public GameObject player;
   public Transform spawn;
   public Vector3 size;
  
    public int slotIndex;
     
   

   #region Singleton 
    public static GearManager instance;
    void Awake()
    {
      
     
        instance = this;
    }

    #endregion

   public Gear[] currentGear ;

    public void Start()
    {   
        inventory = Inventory.instance; 
        int numSlots = System.Enum.GetNames(typeof(Geartypes)).Length;
        currentGear = new Gear[numSlots];
         
    }

    public void SameGear(Gear newItem )
    {
         slotIndex = (int)newItem.geartypes;

        Gear oldItem = null; 
       if (currentGear[slotIndex] != null)
        {
            oldItem = currentGear[slotIndex];       // add the old item to the inventory incase we got 2 items from the same type
            inventory.Add(oldItem);
            Destroy(newgear);                      //destroy current gear prefab on scene 
            
            InteractionHologram.instance.DestroyHologram(InteractionHologram.instance.newHologram); // access to IntercationHologram to destroy the prefab ! 
        }
        currentGear[slotIndex] = newItem;               
    }
    
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
        Debug.Log(newgear);
    }


    public void Spawn()
    {
        if (used == true)
        {
            
            newgear = Instantiate(gearprefab) as GameObject;
            PickUp.instance.item = GearManager.instance.currentGear[GearManager.instance.slotIndex];
            newgear.transform.localScale = size;
          //  gearOldGear = PickUp.instance.item;
          



            Physics.IgnoreCollision(newgear.GetComponent<Collider>(),player.GetComponent<Collider>()) ; 
            Update();
           

            Debug.Log("spaw");
            

        }

    }

}