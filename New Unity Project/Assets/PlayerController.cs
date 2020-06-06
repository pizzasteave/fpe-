using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform camOffset; 
    public CharacterController controller;
    public float speed = 6f;
    public float smoothTime = 0.01f;
    private float smoothVelocity; 

    // Update is called once per frame
    void Update()
    {
       
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized; 

        if ( direction.magnitude >= 0.01f ){
            // rotation and smoothness
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camOffset.eulerAngles.y; //tangente opposé / adjascant 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);  // we can use lerp ! 
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //move the player 

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            controller.Move(moveDirection.normalized * speed * Time.deltaTime); 
        }
    }
}
