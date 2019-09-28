using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubePlacer : MonoBehaviour
{
    public GameObject[] TowerArray = new GameObject[3];

    private TowerGrid grid;
    




    private void Awake()
    {
        grid = FindObjectOfType<TowerGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceCubeNear(hitInfo.point);
            }
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        Instantiate(TowerArray[0], finalPosition, Quaternion.identity);

    }
}
