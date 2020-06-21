﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookraduis;
     Transform target;
    NavMeshAgent agent;
    Rigidbody rb;
    Vector3 offSet; 
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.playerposition.transform;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        offSet = new Vector3 (0.7f,0, 0.7f); 
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookraduis)
        {

            agent.SetDestination(target.position + offSet);
            FaceTarget();

          
            
          /*  if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
             
            }*/

        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookraduis); 
    }

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotaion = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotaion, Time.deltaTime * 5f); 



    }
    private void OnTriggerEnter(Collider other)
    {
      if (other == PlayerController.instance.GetComponent<Collider>())
        {
            PlayerController.instance.Speed -= 2f;

        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerController.instance.GetComponent<Collider>())
        {
            PlayerController.instance.Speed += 2f;

        }
    }
}
