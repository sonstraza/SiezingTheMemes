using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Create an aray
        // spawn enem1ies by number
        // add each enemy to the array
            // activate each enemy one by one 
    public GameObject spawnPoint;

    private void Awake()
    {
//        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject spawnObj = CnvMechObjPoolSgtMan.instance.GetPooledObjectRandom();
            spawnObj.transform.position = spawnPoint.transform.position;
            spawnObj.GetComponent<MechCharStatHP>().currentHP = spawnObj.GetComponent<MechCharStatHP>().maxHP;
            
            spawnObj.SetActive(true);
            /// heal 
        }
    }
}
