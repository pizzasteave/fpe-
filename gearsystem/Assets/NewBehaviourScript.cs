using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int speed; 
    public Rigidbody rb;
  public  Vector3 vector; 
    // Start is called before the first frame update
    void Start()
    {
       vector = new Vector3(0, speed , 0); 
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
