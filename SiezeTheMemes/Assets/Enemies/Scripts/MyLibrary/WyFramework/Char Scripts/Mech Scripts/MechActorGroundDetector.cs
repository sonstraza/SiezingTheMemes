using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///     This class detects if a gameObject is touching the ground or a Prop that has a collider
///         
///     Explanation:
///             - Whenever your character's feet touches the ground, isGrounded becomes true,
///             - isGrounded will become false if your character jumps and is no longer touching the ground
///                 - e.g if isGrounded, canJump = true. Else, canJump = false       
///     Usage:
///         - Access a reference to a gameObj with this script attached
///         - Get the isGrounded boolean from it and implement it with your gameplay Logic.             
///     Integration:
///         - Attach this script to a gameObject
///         - Attach a collision and a rigidbody to the gameObject
///         - Set the gameObject's LayerMask to "PropCol"
///         - Attach and position this gameObject to your character's feet
/// 
/// </summary>
public class MechActorGroundDetector : MonoBehaviour
{
    public bool isGrounded;
    // Start is called before the first frame update        

    // add new collision layer as 8 for ground detection

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "PropCol")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "PropCol")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "PropCol")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "PropCol")
        {
            isGrounded = false;
        }
    }
}


// old get layer         if(other.gameObject.layer == 8 ){