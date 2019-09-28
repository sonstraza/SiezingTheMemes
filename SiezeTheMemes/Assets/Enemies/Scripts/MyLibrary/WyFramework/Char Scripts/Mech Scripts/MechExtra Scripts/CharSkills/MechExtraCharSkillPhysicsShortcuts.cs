using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Static
public class MechExtraCharSkillPhysicsShortcuts
{
    
    
    
    /*
     *  This function adds velocity to an object that is passed as PushObject away from the Origin
     */
    public static void LaunchObjBy2Transforms(Transform pushedObject, Transform origin, float pushBackForce){
        Vector3 pushDirection = new Vector3(0, (pushedObject.position.y - origin.position.y),0 ).normalized; // normalized returns unit vector
        pushDirection*=pushBackForce;

        if (pushedObject.GetComponent<Rigidbody2D>()) //2d pushedObject
        {
            Rigidbody2D pushedRB = pushedObject.GetComponent<Rigidbody2D>();
            pushedRB.velocity = Vector3.zero;
            pushedRB.AddForce(pushDirection, ForceMode2D.Impulse); // impulse is the explosive type of force
        }
        if (pushedObject.GetComponent<Rigidbody>()) //3d pushedObject
        {
            Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();
            pushedRB.velocity = Vector3.zero;
            pushedRB.AddForce(pushDirection, ForceMode.Impulse); // impulse is the explosive type of force
        }


    }
}

