using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private Transform player;
    public Transform firePoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    int enemyHP = 2;


	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
	}
	
	
	void Update ()
    {
        Vector3 diff = player.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(-diff.x, diff.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot_z);


        // if the enemy is too far away, he'll move closer to the target
		if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        // if he's close but not too close, the enemy will stop moving
        else if(Vector2.Distance(transform.position, player.position) == stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        // lastly, if the enemy is too close to the player, he'll retreat
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBtwShots <= 0)
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            enemyHP--;
            if(enemyHP <= 0)
                Destroy(gameObject);
        }
    }

}
