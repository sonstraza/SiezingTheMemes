using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class 
///<summary> 
///     This class locks the position of your camera in relation to a gameObj reference, to create a feeling that the camera following the object referenced in RunTime
///         
///     Explanation:

/// 		
///     Usage:

/// 		
///     Integration:

///     Implement Later:
///
/// 
/// </summary>
public class CnvCameraFollowObj : MonoBehaviour
{

    public GameObject target;       //Public variable to store a reference to the player game object
    public bool useCustomOffset;
    public Vector3 offset;         //Private variable to store the offset distance between the player and camera

    public bool LockCamera_XAxis;
    void Start () 
    {

    }
    // Use this for initialization
    void Awake () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        if(!useCustomOffset){
            offset = transform.position - target.transform.position;
        }
    }
    
    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        // transform.position = target.transform.position + offset;
        transform.position = target.transform.position + offset;


        //Lock Camera
        if(LockCamera_XAxis)
            offset = new Vector3(0,offset.y,offset.z);
    }
}
