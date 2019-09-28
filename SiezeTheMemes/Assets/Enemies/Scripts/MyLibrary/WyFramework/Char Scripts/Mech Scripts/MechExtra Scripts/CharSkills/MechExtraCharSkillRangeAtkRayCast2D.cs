using System;
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
public class MechExtraCharSkillRangeAtkRayCast2D : MonoBehaviour
{
    public float range = 10f;
    public float damage = 5f;
    public float pushBackForce;


    RaycastHit2D shootHit; //Anything that's hit by the raycast
    int shootableMask;
    LineRenderer gunLine;

    public bool bInvertRaycastDirection;
    public float offsetMultiplier = 1;

    // Start is called before the first frame update
    void Update()
    {
        shootableMask = LayerMask.GetMask("PropCol");
        gunLine = GetComponent<LineRenderer>();
        gunLine.SetPosition(0,transform.position);
        
        // invert direction check
        if (bInvertRaycastDirection)
        {
            offsetMultiplier = -Mathf.Abs(offsetMultiplier); // right
        }
        else
        {
            offsetMultiplier = Mathf.Abs(offsetMultiplier); // right
        }
     
        shootHit = Physics2D.Raycast(transform.position,  transform.right * offsetMultiplier , range, shootableMask);
        if (shootHit.collider != null)
        {            
            gunLine.SetPosition(1,shootHit.point );
            Debug.Log(gameObject.name + " 2DRaycasthit: " + shootHit.collider.name);


            GameObject targetObj = shootHit.collider.gameObject;
            MechCharStatHP targetMechCharStatHP = targetObj.GetComponent<MechCharStatHP>();
            
            if(targetMechCharStatHP)
                targetMechCharStatHP.ApplyDamage(damage);

            MechExtraCharSkillPhysicsShortcuts.LaunchObjBy2Transforms(shootHit.collider.transform,transform, pushBackForce);
        }
        else gunLine.SetPosition(1, transform.position + transform.right * range * offsetMultiplier);

        
    }   


}
