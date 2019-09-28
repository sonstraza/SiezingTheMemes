using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    EnemyState enemyState;
    public enum EnemyState {
             ALIVE,
             DEAD,
             WALKING,
             IDLE,
             ATTACKING
    };

    



}
