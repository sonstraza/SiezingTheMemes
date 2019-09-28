using TMPro;
using UnityEngine;
public class Cnv_DetectCollision : MonoBehaviour
{

    public bool isTriggerEntered;
    public string currentCompareTag = "Player";

    public int crossHairHitboxIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        isTriggerEntered = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == currentCompareTag)
        {
            isTriggerEntered = true;

        }

    }
}
