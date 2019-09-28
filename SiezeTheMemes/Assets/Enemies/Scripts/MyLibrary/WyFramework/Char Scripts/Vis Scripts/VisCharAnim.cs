using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class 
///<summary> 
///     This class contains the functions that will perform the In-Game Animations of each characters when called by managing/manipulating the Unity's Animation Parameters
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
/// 
public class VisCharAnim : MonoBehaviour
{
   private Animator myAnim;
   private MechActorGroundDetector externalGD;

    void Awake() {
        myAnim = GetComponent<Animator>();
        externalGD = transform.root.GetComponentInChildren<MechActorGroundDetector>();
        
    }

    private void Update() {
        //set anim param for update
        myAnim.SetBool(CnvAnimTags.GROUND_BOOL,externalGD.isGrounded);
    }

    public void Walk(float walk){
        myAnim.SetFloat(CnvAnimTags.WALK,walk);
        
    }
    public void Attack1(){
         myAnim.SetTrigger(CnvAnimTags.ATTACK_1_TRIGGER);
    }
    public void Attack2(){
         myAnim.SetTrigger(CnvAnimTags.ATTACK_2_TRIGGER);
    }
    public void Attack3(){
         myAnim.SetTrigger(CnvAnimTags.ATTACK_3_TRIGGER);
    }

    public void Jump(){
         myAnim.SetTrigger(CnvAnimTags.JUMP_TRIGGER);
    }

    public void isGroundFalling(bool isGrounded){
        myAnim.SetBool(CnvAnimTags.GROUND_BOOL, isGrounded);
    }



    // ENEMY ANIMATIONS
    public void EnemyAttack(int attack){
        if(attack == 0){
            myAnim.SetTrigger(CnvAnimTags.ATTACK_1_TRIGGER);
        }
        if(attack == 1){
            myAnim.SetTrigger(CnvAnimTags.ATTACK_2_TRIGGER);
        }
        if(attack == 2){
            myAnim.SetTrigger(CnvAnimTags.ATTACK_3_TRIGGER);
        }
        
    }

    public void Play_IdleAnimation(){
        
        // Play animation by name
        myAnim.Play(CnvAnimTags.IDLE_ANIMATION);
    }

    public void KnockDown(){
        myAnim.SetTrigger(CnvAnimTags.KNOCK_DOWN_TRIGGER);
    }
    
    public void StandUp(){
        myAnim.SetTrigger(CnvAnimTags.STAND_UP_TRIGGER);
    }
    public void Hit(){
        myAnim.SetTrigger(CnvAnimTags.HIT_TRIGGER);
    }
    public void Death(){
        myAnim.SetTrigger(CnvAnimTags.DEATH_TRIGGER);

    }






}
