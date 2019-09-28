using UnityEngine;

public class CnvCameraDrag : MonoBehaviour
{
    public float dragSpeed = 40;
    private Vector3 oldPosition;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldPosition = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        if (oldPosition == Input.mousePosition)
            return;
        Vector3 pos = Camera.main.ScreenToViewportPoint(oldPosition - Input.mousePosition);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed * 0);

        transform.Translate(move, Space.World);
        oldPosition = Input.mousePosition;
    }
}