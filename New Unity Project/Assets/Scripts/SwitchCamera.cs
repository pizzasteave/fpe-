using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{    public CinemachineVirtualCamera camgearsystem ;
    public CinemachineFreeLook currnetCam;
    public GameObject gearspawn; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(PlayerController.instance.transform.position, gearspawn.transform.position);
        Debug.Log(distance);
        if (distance <= 1f)
        {
            camgearsystem.Priority = 11;
            currnetCam.Priority = 10; 

        }
        else {
            currnetCam.Priority = 11;
            camgearsystem.Priority = 10;
        }
    }
}
