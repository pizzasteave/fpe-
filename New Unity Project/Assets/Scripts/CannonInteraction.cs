using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonInteraction : MonoBehaviour
{
    public GameObject GFXPlayer; 
    public CinemachineFreeLook currentCam;
    public CinemachineVirtualCamera cannonCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if (CheckCloseCannon("Player",2f))
        { if (Input.GetMouseButtonDown(0))
            {
                currentCam.Priority = 10;
                cannonCam.Priority = 12;
                GFXPlayer.SetActive(false);
                RotateProjectileToMouse.instance.used = true;
                CursorLock.instance.usingST = true;
                
                
            }
        } else 
        {
         
            RotateProjectileToMouse.instance.used = false;
            currentCam.Priority = 12;
            cannonCam.Priority = 10;
            GFXPlayer.SetActive(true);
            CursorLock.instance.usingST = false;

        }

    }

    public bool CheckCloseCannon(string tag, float minimumDistance)
    {
        GameObject[] goWithTag = GameObject.FindGameObjectsWithTag(tag);

        for (int i = 0; i < goWithTag.Length; ++i)
        {
            if (Vector3.Distance(transform.position, goWithTag[i].transform.position) <= minimumDistance)
                return true;
        }

        return false;
    }
}
