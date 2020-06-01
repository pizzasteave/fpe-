using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GearRotation : MonoBehaviour
{
    #region Singleton 
    public static GearRotation instance;
    void Awake()
    {
        instance = this;
    }

    #endregion

    public float speed;
    public float angularSpeed; 
    public Rigidbody rb;
    public Vector3 vector;
    public bool triggred;
    public bool doura;
   
    public Quaternion firstRotation;
    int pi; 
  
    // Start is called before the first frame update
    void Start()
    {
        doura = false; 
       
        // Debug.Log(firstRotation = transform.localRotation) ;

       

    }
   /*  void Update()
    {
       // Debug.Log (Mathf.DeltaAngle (firstRotation, transform.localRotation));

   

    }*/
    // Update is called once per frame
    public void FixedUpdate()
    {

        if (triggred == true  )
        {
            Debug.Log(triggred); 
         if ( doura == false )
            {


           StartCoroutine(ExampleCoroutine());
            

                Debug.Log("here");


            }
           
        }
        doura = false;  
    }

       public IEnumerator ExampleCoroutine()
    {
        speed = rb.velocity.magnitude;
        angularSpeed = rb.angularVelocity.magnitude * Mathf.Rad2Deg;
        rb.angularVelocity = new Vector3(0, 0, Mathf.PI/2);
        Debug.Log( rb.rotation.eulerAngles.x);  
        /*  vector = new Vector3(0, speed, 0);


           Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);

           rb.MoveRotation( rb.rotation *  deltaRotation);


         Debug.Log( rb.rotation.eulerAngles.x); */


        
        yield return new WaitForSecondsRealtime(4);
        Debug.Log ("360");
        doura = true;
        triggred = false; 
        rb.angularVelocity = new Vector3(0, 0, 0);
        yield break; 
    
       
    
      
    }


  
}
