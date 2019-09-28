using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**

This class gets a line renderer in this object, and then set its end points based on its target. 
        
Explanation:
 
Usage:


Integration:
    - Attach this class script to an Obj with LineRenderer attached to it.
    - Line Renderer will automatically set its endPoint as the target that is passed in this script
    - You can swap the target endPoint by calling the SwapTarget function
    - You can reset the target to the initial default target by calling the ResetTarget function
    - You can make the LineRenderer target any child obj under this Obj by calling the SetLineTargetChildObject function


Implement Later:

 */
public class CnvDrawLineRen : MonoBehaviour
{

    // if not set, use this obj transform as origin
    public Transform origin;
    // if not set, use this obj transform as target, so LineRen won't set endPoint as 0,0,0 
    public Transform target;

    private Transform defaultTarget;

    public bool targetIsChild;
    
    // if not set, use this obj's LineRen as line
    public LineRenderer line;

    // Use this for initialization

    void Awake()
    {
        if (!target)
            target = transform;
        
        defaultTarget = target;
        
        if(!line)
            line = GetComponent<LineRenderer>();
        
        if (!origin)
            origin = transform;
            
    }

    void Update()
    {
        SetLinePoints(origin.position,target.position);
        
    }

    // This function sets the StartPoint and EndPoint of the LineRenderer
    private void SetLinePoints(Vector3 startPoint, Vector3 endPoint)
    {

        this.target = target;
        line.SetPosition(0, startPoint);
        line.SetPosition(1, endPoint);
    }
    
    //This function swaps target end point of linerenderer with another target. Call this function to change endPoint of lineRenderer
    public void SwapTarget(Transform swappedTarget)
    {
        target = swappedTarget;
    }
    // This function resets the target endPoint of the Line Renderer to the default target, in case it has been changed
    public void ResetTarget()
    {
        target = defaultTarget;
    }
    
    /**
    Function adapted from Drone Chinery Abandoneware
    This function will attach line Renderer to any child objects of this object
    Explanation:
        - Whenever there is more than 0 child attached to this object
        - Set first child object as endpoint
    Usage:
        - 
            
    Integration:
        - Call this function to make line renderer set its endpoint as targetChildObject
     */
    public void SetLineTargetChildObject(){
        if (targetIsChild)
        {
            if (transform.childCount > 0)
            {
                SetLinePoints(line.transform.position,transform.GetChild(0).gameObject.transform.position);
            }
            else
            {
                ResetTarget();
            }
        }
    }



}
