using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

///<summary> 
///     This class performs a spherecast that detects any character near it and apply damage to them , and push them back in recoil
///         
///     Explanation:

/// 		
///     Usage:
///         - Best used in MeleeWeapons or Attacks
/// 		
///     Integration:

///    
/// </summary>
/// 
public class MechExtraCharSkillMeleeAtkSphrCastPushback : MonoBehaviour // melee atk sphr cast
{
    public float damage;
    public float knockBackRadius;
    [FormerlySerializedAs("meleeRate")] public float fireRate;
    float nextMelee;
    int shootableMask;
    // Animator myAnim;
    public float pushBackForce;

    public bool bIs2DGame = true;
    public bool bDebugTrace = false;
    /// Start is called before the first frame update
    void Start()
    {
        shootableMask = LayerMask.GetMask("PropCol");
//        myAnim = transform.root.GetComponentInChildren<Animator>();    
        nextMelee = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxis("Jump")>0){
            UseItemAbility();
        }
    }

    public void UseItemAbility(){
        //sphr cast and attack all objects with PropCol layerMask in it
        if(nextMelee < Time.time){
            nextMelee = Time.time + fireRate;

            //do damage
            if (bIs2DGame) // for 2D Games
            {
                Collider2D[] target = Physics2D.OverlapCircleAll(transform.position, knockBackRadius, shootableMask);

                if (bDebugTrace)
                {
                    DebugExtension.DebugWireSphere(transform.position,Color.red,knockBackRadius);
                }

                foreach (Collider2D tCol in target)
                {
                    
                    MechCharStatHP targetMechCharStatHP = tCol.GetComponent<MechCharStatHP>();
                    if (targetMechCharStatHP)
                    {
                        targetMechCharStatHP.ApplyDamage(damage);
                        MechExtraCharSkillPhysicsShortcuts.LaunchObjBy2Transforms(tCol.gameObject.transform,transform, pushBackForce);

                    }
                }
                
            }
            
            else // for 3D Games
            {
                Collider[] target = Physics.OverlapSphere(transform.position, knockBackRadius, shootableMask);

                if (bDebugTrace)
                {
                    DebugExtension.DebugWireSphere(transform.position,Color.red,knockBackRadius);
                }
                print(target.Length);

                foreach (Collider tCol in target)
                {
                    MechCharStatHP targetMechCharStatHP = tCol.GetComponent<MechCharStatHP>();
                    if (targetMechCharStatHP)
                    {
                        targetMechCharStatHP.ApplyDamage(damage);
                        MechExtraCharSkillPhysicsShortcuts.LaunchObjBy2Transforms(tCol.gameObject.transform,transform, pushBackForce);
                    }    
                }


            }
        }
    }
    

    
}