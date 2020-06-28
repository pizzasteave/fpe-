using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]

public class RaycastReflection : MonoBehaviour
{
    public int reflections;
    public float maxDistance;

    private LineRenderer linerender;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;

    private void Awake()
    {
        linerender = GetComponent<LineRenderer>(); 
    }

    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        linerender.positionCount = 1;
        linerender.SetPosition(0, transform.position);
        float remainingDistance = maxDistance; 
        for ( int i =0; i < reflections; i++ )
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit , remainingDistance))
            {
                linerender.positionCount += 1; 
                linerender.SetPosition(linerender.positionCount - 1, hit.point);
                remainingDistance -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                if (hit.collider.tag != "Mirror")
                    break;
            }

            else
            {
                linerender.positionCount += 1;
                linerender.SetPosition(linerender.positionCount  - 1, ray.origin + ray.direction * remainingDistance); 


            }


        }
    }
}