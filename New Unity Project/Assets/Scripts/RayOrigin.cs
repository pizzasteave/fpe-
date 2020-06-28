using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RayOrigin : MonoBehaviour
{
    
    public int maxReflectionCount = 5;
    public float maxStepDistance = 200;

    private Transform goTransform;
    private LineRenderer lineRenderer;
    private int nPoints;
    void Awake()
    {
        //get the attached Transform component  
        goTransform = this.GetComponent<Transform>();
        //get the attached LineRenderer component  
        lineRenderer = this.GetComponent<LineRenderer>();
    }

  
    void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.ArrowHandleCap(0, this.transform.position + this.transform.forward * 0.25f, this.transform.rotation, 0.5f, EventType.Repaint);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 0.25f);

        DrawPredictedReflectionPattern(this.transform.position + this.transform.forward * 0.75f, this.transform.forward, maxReflectionCount);
    }

    private void DrawPredictedReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0)
        {
            return;
        }
       
        Vector3 startingPosition = position;
      
        Ray ray = new Ray(position, direction);
        RaycastHit hit;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, goTransform.position);
        
        if (Physics.Raycast(ray, out hit, maxStepDistance))
        {
            lineRenderer.positionCount += 1;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
           
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
            


        }
        else
        {
            position += direction * maxStepDistance;
            nPoints++; 
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * reflectionsRemaining);
            
    
            

        }

        Gizmos.color = Color.black;
        
        Gizmos.DrawLine(startingPosition, position);

       

        DrawPredictedReflectionPattern(position, direction, reflectionsRemaining - 1);
    }
}
