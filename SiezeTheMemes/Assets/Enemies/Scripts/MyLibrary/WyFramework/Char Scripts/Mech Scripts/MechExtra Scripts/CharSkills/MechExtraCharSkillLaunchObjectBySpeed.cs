using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///<summary> 
///     This class adds force to a gameObj and blast it away like a projectile. The Projectile has a collider that apply damage to any character that touches it, and push them back in recoil
///         
///     Explanation:

/// 		
///     Usage:
///        - Best Used with In-Game weapon projectiles or obstacles    
/// 		
///     Integration:

///
///     Implement Later:
///     - Add Pushback force 
/// 
/// </summary>
/// 
public class MechExtraCharSkillLaunchObjectBySpeed : MonoBehaviour
{
    public float damage;
    public float speed;
    public float pushBackForce;

    Rigidbody myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        if(transform.rotation.y>0) {
            myRB.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        }
        else myRB.AddForce(Vector3.forward *-speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PropCol"))
        {
            MechCharStatHP mechCharStatHP = other.gameObject.GetComponent<MechCharStatHP>();
            if (mechCharStatHP)
                mechCharStatHP.ApplyDamage(damage);
            myRB.velocity = Vector2.zero;
            MechExtraCharSkillPhysicsShortcuts.LaunchObjBy2Transforms(other.transform, transform, pushBackForce);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("PropCol"))
        {
            MechCharStatHP mechCharStatHP = other.gameObject.GetComponent<MechCharStatHP>();
            if(mechCharStatHP)
                mechCharStatHP.ApplyDamage(damage);
            myRB.velocity = Vector2.zero;
            MechExtraCharSkillPhysicsShortcuts.LaunchObjBy2Transforms(other.transform, transform, pushBackForce);
            
            Destroy(gameObject);
        }    
    }

    
}