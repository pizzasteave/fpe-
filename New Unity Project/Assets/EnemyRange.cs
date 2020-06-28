using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    #region Singleton 
    public static EnemyRange instance;
    void Awake()
    {
        instance = this;
    }

    #endregion
    public float lookraduis;
    public Transform target;
    public bool playerdetected ; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookraduis)
        {
            playerdetected = true;
           
        }
        else playerdetected = false; 
    }
     private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookraduis); 
    }
}
