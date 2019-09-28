using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
This class explain and describes how the documentation of the Wy framework works.
 
Explanation:
 
Usage:

Integration:

Implement Later:
    - Joystick Twinstick DroneMovement Controls

 */
public class MechCharMovementTopDown : MonoBehaviour
{

    public Vector3 idleForce;
    public float verticalSpeedMultiplier = 1; // multiplier for forward movement force
    public float horiSpeedMultiplier = 1; // multiplier for right movement force


    private float horizontalSpeed = 3f;
    private float verticalSpeed = 3f;

    // Logic
    // public lLogic

    // Non Viewable

    //EditorViewable
    // public var vObj

    //EditorSetRef
    // public var rObj

    // Components in this obj
    //public var myComp;
    private Rigidbody myRB;

    // CustComponents in this obj
    //public var myCustComp;

    // Components in Child
    //public var _child_Comp
    private Animator child_Animator;

    // CustComponents in Child
    //public var _child_CustComp
    public MechActorGroundDetector child_cust_mechActorGroundDetector;
    public VisCharAnim child_cust_visCharAnim;

    // Components in External
    //public var _ex_Comp

    // CustComponents in External
    //public var _ex_CustComp

    // Components in External Child
    //public var _ex_child_Comp

    // CustComponents in External Child
    //public var _ex_child_CustComp


    // Start is called before the first frame update
    void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        child_Animator = GetComponentInChildren<Animator>();
        child_cust_mechActorGroundDetector = GetComponentInChildren<MechActorGroundDetector>();
        child_cust_visCharAnim = GetComponentInChildren<VisCharAnim>();

        horizontalSpeed *= horiSpeedMultiplier;
        verticalSpeed *= verticalSpeedMultiplier;



    }

    // Update is called once per frame
    void Update()
    {

        MoveForward(Input.GetAxis("Vertical"));

        MoveRight(Input.GetAxis("Horizontal"));


        meshRotation();
        MoveUp(Input.GetAxis("Fire1"));
        MoveUp(-Input.GetAxis("Fire2"));

        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }


        //Animator params // called in VisCharAnim
        child_cust_visCharAnim.Walk(myRB.velocity.magnitude);
        child_cust_visCharAnim.isGroundFalling(child_cust_mechActorGroundDetector.isGrounded);
    }

    public void MoveRight(float AxisValue)
    {
        Vector3 direction = transform.right * (horizontalSpeed * AxisValue);
        myRB.AddForce(direction);

    }
    public void MoveForward(float AxisValue)
    {
        Vector3 direction = transform.forward * (horizontalSpeed * AxisValue);

        myRB.AddForce(transform.forward * (horizontalSpeed * AxisValue));

    }

    public void Jump()
    {
        if (child_cust_mechActorGroundDetector.isGrounded) {
            myRB.AddForce(new Vector3(0, verticalSpeed, 0), ForceMode.Impulse);
        }
    }

    public void meshRotation()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
           if(moveHorizontal>0.1|| moveHorizontal<-0.1 ||moveVertical>0.1 || moveVertical < -0.1){
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            child_Animator.transform.rotation = Quaternion.LookRotation(movement);


            child_Animator.transform.Translate(movement * 0.1f * Time.deltaTime, Space.World);
        }
    }

    //Move U/Downp Like A Helicopter
    public void MoveUp(float AxisValue)
    {

        myRB.AddForce(transform.up * (verticalSpeed * AxisValue));
    }





}