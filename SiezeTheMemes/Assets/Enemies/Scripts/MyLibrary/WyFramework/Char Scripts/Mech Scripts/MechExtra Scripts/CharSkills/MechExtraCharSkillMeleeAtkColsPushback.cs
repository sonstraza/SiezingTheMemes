using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

*/
///<summary> 
///     This class uses a collider that apply damage to any character that touches it, and push them back in recoil
///         
///     Explanation:
/// 		
///     Usage:
///         - Best used in Hazard/Melee Obstacles or Weapons, prefer MeleeAtkSprCast for MeleeWeapons
/// 		
///     Integration:
/// 
/// </summary>
public class MechExtraCharSkillMeleeAtkColsPushback : MonoBehaviour // melee attack collision
{
    public float damage;
    public float damageRate;
    public float pushBackForce;

    float fireRate; // time when damage is possible


    // Start is called before the first frame update
    void Start()
    {
        fireRate = Time.time;
    }


    void Attack(GameObject targetObj)
    {
        MechCharStatHP targetMechCharStatHP = targetObj.GetComponent<MechCharStatHP>();

        if (targetMechCharStatHP != null)
        {
            if (fireRate <= Time.time)
            {
                targetMechCharStatHP.ApplyDamage(damage);
                fireRate = Time.time + damageRate;

                MechExtraCharSkillPhysicsShortcuts.LaunchObjBy2Transforms(targetObj.transform, transform, pushBackForce);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject)
        {
            Attack(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            Attack(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            Attack(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Attack(other.gameObject);
        }
    }
}