using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 10;
    public int damage = 10;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    private float distance;
    private float startTime;

    //private GameManagerBehavior gameManager;

    

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
    }

    // Update is called once per frame
    void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);


        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                /* // 3
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar =
                    healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= Mathf.Max(damage, 0);

                */
                // 4
                if (enemy.currentHealth <= 0)
                {
                    Destroy(target);
                  

                    gameManager.Materials += 50;
                }
            }
            Destroy(gameObject);
        }
    }
}
