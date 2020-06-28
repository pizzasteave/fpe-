using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    #region Singleton 
    public static EnemyController instance;
    void Awake()
    {
        instance = this;
    }

    #endregion
    Transform target;
    NavMeshAgent agent;
    Rigidbody rb;
    Vector3 offSet;

    public Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.playerposition.transform;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        offSet = new Vector3 (0.7f,0, 0.7f); 

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        if (!EnemyRange.instance.playerdetected)
        {
           
            Vector3 temp = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-10f, 10f)) + EnemyRange.instance.transform.position;
            Debug.Log(temp);
            agent.SetDestination(temp * 3); 
            
        }
        if (EnemyRange.instance.playerdetected)
        {
           
            agent.SetDestination(target.position + offSet);
            FaceTarget();

          
            
          /*  if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
             
            }*/

        }
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
