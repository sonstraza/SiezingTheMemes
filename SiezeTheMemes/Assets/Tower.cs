using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int energyCost;
    public int materialCost;
    public GameObject projectile;
    public int fireRate;
    public List<GameObject> enemiesInRange;

    private float lastShotTime;
   // private MonsterData monsterData;


    // Start is called before the first frame update
    void Start()
    {
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = null;
        // 1
      //  float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {
            /*
            float distanceToGoal = enemy.GetComponent<MoveEnemy>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
            */
            target = enemy;


            
        }
        // 2
        if (target != null)
        {
            if (Time.time - lastShotTime > fireRate)
            {
                attack(target.GetComponent<SphereCollider>());
                lastShotTime = Time.time;


                /*
                 foreach(GameObject enemy in enemiesInRange)
                 {
                    Transform healthBarTransform = target.transform.Find("HealthBar");
                    HealthBar healthBar =
                    healthBarTransform.gameObject.GetComponent<HealthBar>();
                    healthBar.currentHealth -= Mathf.Max(damage, 0);
                 }
                */
            }
            // 3

            /*
            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(
                Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,
                new Vector3(0, 0, 1));
                */
        }
    }

    void attack(SphereCollider target)
    {
        GameObject bulletPrefab = projectile;
        // 1 
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;

        // 2 
        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        ProjectileBehavior bulletComp = newBullet.GetComponent<ProjectileBehavior>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;

        // 3 
        /*
        Animator animator =
            monsterData.CurrentLevel.visualization.GetComponent<Animator>();
        animator.SetTrigger("fireShot");
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        */
    
    }

    void attackAOE()
    {

    }

    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter2D(SphereCollider other)
    {
        // 2
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }
    // 3
    void OnTriggerExit2D(SphereCollider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

}
