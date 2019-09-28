using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class 
///<summary> 
///     This class stores all the Tags and string values in the game. If you are familiar with Android Development, this class is just like the string.xml file
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
public class CnvAnimTags // animation tags
{
    public const string WALK = "Walk";





    public const  string ATTACK_1_TRIGGER = "Attack1";
    public const  string ATTACK_2_TRIGGER = "Attack2";
    public const  string ATTACK_3_TRIGGER = "Attack3";

    public const  string IDLE_ANIMATION = "Idle";

    public const  string KNOCK_DOWN_TRIGGER = "KnockDown";
    public const  string STAND_UP_TRIGGER = "Standup";
    public const  string HIT_TRIGGER = "Hit";
    public const  string DEATH_TRIGGER = "Death";
    public const  string JUMP_TRIGGER = "Jump";

    public const  string GROUND_BOOL = "grounded";

}

public class CnvAxisTags {
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
}

public class CnvGenTags { // general tags
    public const string GROUND_TAG = "Grounds";
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";

    public const string LEFT_ARM_TAG = "LeftArm";
    public const string LEFT_LEG_TAG = "LeftLeg";
    public const string UNTAGGED_TAG = "Untagged";
    public const string MAIN_CAMERA_TAG = "MainCamera";
    public const string HEALTH_UI = "HealthUI";

    public const string ITEM_WEAPON = "ItemWeapon";

}

public class CnvSavePrefsTags{

}