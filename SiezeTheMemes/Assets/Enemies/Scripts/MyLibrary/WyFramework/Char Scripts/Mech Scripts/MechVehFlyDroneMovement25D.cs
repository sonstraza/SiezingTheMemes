using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
This class explain and describes how the documentation of the Wy framework works.
 
Explanation:
 
Usage:

Integration:

Implement Later:

 */
public class MechVehFlyDroneMovement25D : MonoBehaviour
{

    public Vector3 idleForce;
    public float speedMultiplier = 1; // multiplier for movement force

    private float horizontalSpeed = 3f;
    private float verticalSpeed = 3f;
    public float horizontalRot =3f;

    Rigidbody myRB;
    public GameObject vehMesh; // set this to make drone lean forward via rotating while moving

    // Start is called before the first frame update
    void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        horizontalSpeed *= speedMultiplier;
        verticalSpeed *= speedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        MoveHorizontal(Input.GetAxis("Horizontal"));
        
        MoveVertical(Input.GetAxis("Vertical"));


        myRB.AddForce(idleForce); // force added to Drone at all times
        myRB.AddForce(-idleForce); // inertia force added to Drone at all times


//        clamp rotation
         if( (transform.rotation.z <=-30 || transform.rotation.z >=30 ) || Input.GetAxis("Horizontal") == 0){
             vehMesh.transform.rotation = Quaternion.Slerp(vehMesh.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * horizontalRot);
         }

    }

    public void MoveHorizontal(float AxisValue){
        myRB.AddForce( transform.right * (horizontalSpeed * AxisValue) );
        if(vehMesh)
            vehMesh.transform.rotation = Quaternion.Slerp(vehMesh.transform.rotation, Quaternion.Euler(-30* AxisValue * transform.forward), Time.deltaTime * horizontalRot);
    }

    public void MoveVertical(float AxisValue){
        myRB.AddForce( transform.up * (verticalSpeed * AxisValue) );
    }
    

    


}
