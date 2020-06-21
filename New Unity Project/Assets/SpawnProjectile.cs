using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateProjectileToMouse rotateProjectileToMouse; 

    private GameObject effectSpawn; 

    // Start is called before the first frame update
    void Start()
    {
        effectSpawn = vfx[0]; 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnVFX(); 

        }
    }

    void SpawnVFX()
    {
        GameObject vfx; 
        if (firePoint != null )
        {
            vfx = Instantiate(effectSpawn, firePoint.transform.position, Quaternion.identity);
            vfx.SetActive(true);
            if (rotateProjectileToMouse != null )
            {
                vfx.transform.localRotation = rotateProjectileToMouse.GetRotation(); 

            }
        }else
        {
            Debug.LogError("no firePoint ! "); 
        }


    }
}
