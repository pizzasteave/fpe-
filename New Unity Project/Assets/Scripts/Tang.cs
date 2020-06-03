using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tang : MonoBehaviour
{
  
    public float distance;
    public int intDistance; 
    public int doura;
    public Transform tang;
    public float distance2;  
    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance( tang.position  ,transform.position);
        intDistance = (int) distance; 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(distance);
        Debug.Log(intDistance);
        distance2 = Vector3.Distance(tang.position, transform.position);
        Debug.Log(distance2);

        if (Vector3.Distance(tang.position,transform.position) == distance )
        {
            doura++; 
        }
        Debug.Log(doura); 
    }



}
