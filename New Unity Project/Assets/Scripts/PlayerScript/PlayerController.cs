using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform camOffset; 
    public float speed = 6f;
    public float smoothTime = 0.01f;
    private float smoothVelocity;
    private Vector3 moveDirection;
    private float targetAngle;
    private Vector3 direction;
    private float directionMag;
    private float angle; 
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
     public LayerMask Ground;
    public bool move = false ;
    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
      public bool _isGrounded = true;
    public Transform _groundChecker;
    public Quaternion rotation; 


    void Start()
    {
        _body = GetComponent<Rigidbody>();
      
    }


    // Update is called once per frame
    void Update()
    {

        /* float horizontal = Input.GetAxisRaw("Horizontal");
          float vertical = Input.GetAxisRaw("Vertical");
          Vector3 direction = new Vector3(horizontal, 0, vertical).normalized; 

        if ( direction.magnitude >= 0.01f ){
              // rotation and smoothness
              float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camOffset.eulerAngles.y; //tangente opposé / adjascant 
              float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);  // we can use lerp ! 
              transform.rotation = Quaternion.Euler(0f, angle, 0f);

              //move the player 

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
           //   Quaternion lookRotaion = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
            //  transform.rotation = Quaternion.Slerp(transform.rotation, lookRotaion, Time.deltaTime * 5f);
              //  controller.Move ( moveDirection.normalized * speed * Time.deltaTime);         

          }*/



        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Debug.Log("...");
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        //if (_inputs != Vector3.zero)
        //  transform.forward = _inputs;

        /* if (Input.GetButtonDown("Dash"))
         {
             Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
             _body.AddForce(dashVelocity, ForceMode.VelocityChange);
         }*/




        /* Vector3 x = camOffset.eulerAngles;
         float yangle = x.y;
         Vector3 rot = new Vector3(0, yangle, 0);
         rotation = Quaternion.Euler(0, yangle, 0);*/


    }


    void FixedUpdate()
    {
   

    _inputs.x = Input.GetAxisRaw("Horizontal");
    _inputs.z = Input.GetAxisRaw("Vertical");
    Vector3 direction = new Vector3(_inputs.x, 0, _inputs.z).normalized;
    directionMag = direction.magnitude;

   
    if (directionMag >= 0.01f)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camOffset.eulerAngles.y; //tangente opposé / adjascant 
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);  // we can use lerp ! 
        transform.rotation = (Quaternion.Euler(0f, angle, 0f));
        moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        _body.MovePosition(_body.position + moveDirection.normalized * Speed * Time.deltaTime);
    }
    }


}
