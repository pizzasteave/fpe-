using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScirpt : MonoBehaviour
{
   


   public void  Tirggred()
    {
        Debug.Log("pressed "); 
        GearRotation.instance.triggred = true; 

    }
}
