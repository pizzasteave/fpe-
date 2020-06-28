using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateProjectileToMouse : MonoBehaviour
{
    #region Singleton 
    public static RotateProjectileToMouse instance;
    void Awake()
    {
        instance = this;
    }

    #endregion
    // Start is called before the first frame update
    public bool used;
    public Camera cam; 
    public float maxLength ;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation; 



    // Update is called once per frame
    void Update()
    { if ( cam!= null && used)
        {
            RaycastHit hit;
            var mousepos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousepos);
            if ( Physics.Raycast(rayMouse.origin,rayMouse.direction,out hit, maxLength))
            {

                RotateToMouseDirection(this.gameObject, hit.point); 
            } else
            {
                var pos = rayMouse.GetPoint(maxLength);
                RotateToMouseDirection(this.gameObject, pos);

            }

        }else 
        { Debug.LogError("no cam ! "); }
        
    }

    void RotateToMouseDirection ( GameObject obj , Vector3 destination )
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1); 


    }

    public Quaternion GetRotation ()
    {
        return rotation; 

    }
}
