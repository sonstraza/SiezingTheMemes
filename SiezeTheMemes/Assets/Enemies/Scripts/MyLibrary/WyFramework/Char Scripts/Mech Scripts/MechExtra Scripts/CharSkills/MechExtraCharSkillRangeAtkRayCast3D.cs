using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary> 
///     This class performs a raycast that detects any Character and apply damage to them, and then push them back in recoil
///         
///     Explanation:

/// 		
///     Usage:

/// 		
///     Integration:

///
///     Implement Later:
///     - Add Pushback force 
/// 
/// </summary>
/// 
public class MechExtraCharSkillRangeAtkRayCast3D : MonoBehaviour
{
    public float range = 10f;
    public float damage = 5f;
    public float pushBackForce;


    Ray shootRay;
    RaycastHit shootHit; //Anything that's hit by the raycast
    int shootableMask;
    LineRenderer gunLine;

    // Start is called before the first frame update
    void Update()
    {
        shootableMask = LayerMask.GetMask("PropCol");
        gunLine = GetComponent<LineRenderer>(); 

        shootRay.origin = transform.position;  
        shootRay.direction = transform.forward;
        gunLine.SetPosition(0,transform.position);

        if(Physics.Raycast(shootRay, out shootHit,range , shootableMask)){
            //hit an enemy goes here
            gunLine.SetPosition(1,shootHit.point); // draw line from position of fired all the way to hit point
            Debug.Log(gameObject.name + " 2DRaycasthit: " + shootHit.collider.name);
            
            GameObject targetObj = shootHit.collider.gameObject;
            MechCharStatHP targetMechCharStatHP = targetObj.GetComponent<MechCharStatHP>();
            if(targetMechCharStatHP)
                targetMechCharStatHP.ApplyDamage(damage);
            
            MechExtraCharSkillPhysicsShortcuts.LaunchObjBy2Transforms(shootHit.collider.transform,transform, pushBackForce);
            
            
        } else gunLine.SetPosition(1,shootRay.origin + shootRay.direction * range);
//        shootHit.collider.GetComponent<MechCharStatHP>().ApplyDamage(damage);


    }   


}
