using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CnvCameraRTS : MonoBehaviour
{
    public float CamSpeed = 1f;
    public float GUIsize = 25;
    private float horizontalAxis;
    private float verticalAxis;
    void Start(){
        //Focus Camera On Player On Start

    }

    void Update () {
        //PC Controls via Axis // WASD and UP DOWN LEFT RIGHT
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        if(Input.GetMouseButtonDown(0)){
            Screen.lockCursor = false;
        }

        // from https://www.youtube.com/watch?v=48xnDi0c7FA
        var recdown = new Rect (0, 0, Screen.width, GUIsize);
        var recup = new Rect (0, Screen.height-GUIsize, Screen.width, GUIsize);
        var recleft = new Rect (0, 0, GUIsize, Screen.height);
        var recright = new Rect (Screen.width-GUIsize, 0, GUIsize, Screen.height);

        if (recdown.Contains(Input.mousePosition) || verticalAxis < 0)
            transform.Translate(0, 0, -CamSpeed, Space.World);
        
        if (recup.Contains(Input.mousePosition) || verticalAxis > 0)
            transform.Translate(0, 0, CamSpeed, Space.World);
        
        if (recleft.Contains(Input.mousePosition) || horizontalAxis < 0)
            transform.Translate(-CamSpeed, 0, 0, Space.World);
        
        if (recright.Contains(Input.mousePosition) || horizontalAxis > 0)
            transform.Translate(CamSpeed, 0, 0, Space.World);


        if(Input.GetMouseButtonUp(0)){
            Screen.lockCursor = true;
            Cursor.visible = false;
        }
    }
}