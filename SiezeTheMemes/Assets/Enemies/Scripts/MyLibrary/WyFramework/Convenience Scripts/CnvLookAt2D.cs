using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**

This class makes this gameobject looks towards a target gameObject in 2D 
        
Explanation:
 
Usage:

Integration:

Implement Later:

 */
public class CnvLookAt2D : MonoBehaviour
{
    // Update is called once per frame

    public Transform target;
    public bool targetIsMouse;
    public float offset;
    void Start(){
    }
    void Update()
    {
        LookAt2d();
    }

    private void LookAt2d(){

        if(targetIsMouse)
        {
            Vector3 targetPos = Input.mousePosition;
            targetPos.z = 0;
    
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            targetPos.x = targetPos.x - objectPos.x;
            targetPos.y = targetPos.y - objectPos.y;
    
            float angles = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angles + 90 + offset));            
        }
        else
        {
            Vector3 diff = target.position - transform.position;
            diff.Normalize();
 
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 270 + offset);               
        }

    }
}