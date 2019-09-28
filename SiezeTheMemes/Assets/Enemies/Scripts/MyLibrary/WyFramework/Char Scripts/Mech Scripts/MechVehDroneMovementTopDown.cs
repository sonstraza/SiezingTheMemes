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
public class MechVehDroneMovementTopDown : MonoBehaviour
{

    public Vector3 idleForce;
    public float forwardSpeedMultiplier = 1; // multiplier for forward movement force
    public float horiSpeedMultiplier = 1; // multiplier for right movement force


    private float horizontalSpeed = 3f;
    private float verticalSpeed = 3f;
    public float horizontalRot =3f;

    Rigidbody myRB;
    public GameObject vehMesh; // set this to make drone lean forward via rotating while moving

    // Start is called before the first frame update
    void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        horizontalSpeed *= horiSpeedMultiplier;
        verticalSpeed *= forwardSpeedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
         
        MoveForward(Input.GetAxis("Vertical"));
        
        MoveRight(Input.GetAxis("Horizontal"));
        
        MoveUp(Input.GetAxis("Fire1"));
        MoveUp(-Input.GetAxis("Fire2"));


        myRB.AddForce(idleForce); // force added to Drone at all times
        myRB.AddForce(-idleForce); // inertia force added to Drone at all times


//        clamp rotation
        if( (transform.rotation.z <=-30 || transform.rotation.z >=30 ) || Input.GetAxis("Horizontal") == 0){
            vehMesh.transform.rotation = Quaternion.Slerp(vehMesh.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * horizontalRot);
        }
        
        // if no movement button vert or hori press, decelerate and slowdown speed
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            DecelerateOnIdle();
    }

    public void MoveRight(float AxisValue){
        myRB.AddForce( transform.right * (horizontalSpeed * AxisValue) );
        if(vehMesh)
            vehMesh.transform.rotation = Quaternion.Slerp(vehMesh.transform.rotation, Quaternion.Euler(-30* AxisValue * transform.forward), Time.deltaTime * horizontalRot);

    }
    public void MoveForward(float AxisValue){
        myRB.AddForce( transform.forward * (horizontalSpeed * AxisValue) );
        if(vehMesh)
            vehMesh.transform.rotation = Quaternion.Slerp(vehMesh.transform.rotation, Quaternion.Euler(30* AxisValue * transform.right), Time.deltaTime * horizontalRot);

    }
    public void MoveUp(float AxisValue){
        myRB.AddForce( transform.up * (verticalSpeed * AxisValue) );
    }

    public void DecelerateOnIdle()
    {
        myRB.velocity = Vector3.Lerp( myRB.velocity, new Vector3(0, 0, 0), Time.deltaTime);

    }
    


}