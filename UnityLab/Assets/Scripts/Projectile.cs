using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;

    private Transform player;
    private Transform wall;
    private Vector2 target;


	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        wall = GameObject.FindGameObjectWithTag("Wall").transform;

        target = new Vector2(player.position.x, player.position.y);
    }
	

	void Update ()
    {
        // the projectile moves towards the last known location of the player
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // if it reaches that location without hitting the player, destroy it
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
	}

    // if the projectile hits the player, destroy it
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            DestroyProjectile();
    }

    // function that destroys the projectile
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
