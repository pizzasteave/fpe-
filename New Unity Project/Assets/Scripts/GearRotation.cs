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
    public bool dourabar;

    public Vector3 firstRotationVector ;
    public Vector3 firstPositionVector; 
  
    // Start is called before the first frame update
    void Start()
    {
          doura = false;
        dourabar = true; 

        // Debug.Log(firstRotation = transform.localRotation) ;

        firstRotationVector = rb.rotation.eulerAngles;
     
        firstPositionVector = rb.position;

    }
    /* void Update()
    {
        // Debug.Log (Mathf.DeltaAngle (firstRotation, transform.localRotation));

        

    }*/
    // Update is called once per frame
    public void Update()
    {


        /* if (triggred == true )
         {

             vector = new Vector3(0, speed, 0);


             Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);

             rb.MoveRotation(rb.rotation * deltaRotation);


         }*/
        if (triggred == true && doura == false   )
          {

            StartCoroutine(ExampleCoroutine()); 

        }

        doura = false;
        dourabar = true;


    }

     public IEnumerator ExampleCoroutine()
  {
        speed = rb.velocity.magnitude;
        angularSpeed = rb.angularVelocity.magnitude * Mathf.Rad2Deg;
        rb.angularVelocity = new Vector3(0, 0, Mathf.PI/2);
 
        //  vector = new Vector3(0, speed, 0);


        //   Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);

        //   rb.MoveRotation( rb.rotation *  deltaRotation);


      //   Debug.Log( rb.rotation.eulerAngles.x); 


        
        yield return new WaitForSecondsRealtime(4);
     
            ResetGear();
       
   }



    public void ResetGear()
    {

        if (dourabar == true)
        {
            triggred = false;
            Debug.Log(triggred);
            Debug.Log("360");
            doura = true;
            dourabar = false;


            rb.angularVelocity = new Vector3(0, 0, 0);

            Vector3 tmp = firstRotationVector;
            transform.eulerAngles = tmp;

            Vector3 tmp2 = firstPositionVector;
            Debug.Log(transform.position);
            transform.position = tmp2;
        }
       
    }

}
