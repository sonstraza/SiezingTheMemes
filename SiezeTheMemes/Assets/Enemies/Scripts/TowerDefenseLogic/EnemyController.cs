using System;
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

    private void Awake()
    {
        enemyState = EnemyState.IDLE;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        enemyState = EnemyState.ATTACKING;
    }
}
