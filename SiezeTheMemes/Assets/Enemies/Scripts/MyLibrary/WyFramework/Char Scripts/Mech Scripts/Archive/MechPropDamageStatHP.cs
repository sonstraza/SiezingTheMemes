using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class
///<summary> 
///     This class damages your character when your character touches a collider
///         
///     Explanation:

/// 		
///     Usage:

/// 		
///     Integration:

/// 
/// </summary>

public class MechPropDamageStatHP : MonoBehaviour
{
    public float dmg = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            MechCharStatHP mechCharStatHPComp = other.GetComponent<MechCharStatHP>();
            if (mechCharStatHPComp)
            {
                mechCharStatHPComp.ApplyDamage(dmg);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject)
        {
            MechCharStatHP mechCharStatHPComp = other.gameObject.GetComponent<MechCharStatHP>();
            if (mechCharStatHPComp)
            {
                mechCharStatHPComp.ApplyDamage(dmg);
            }
        }    
    }
}