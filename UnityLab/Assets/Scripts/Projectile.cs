using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;

    private Transform player;
    private Transform wall;
    private Vector2 target;

    private bool ceva = true;
    public Rigidbody2D rb;
    public float ReflectSpeed;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        wall = GameObject.FindGameObjectWithTag("Wall").transform;

        target = new Vector2(player.position.x, player.position.y);
        rb = GetComponent<Rigidbody2D>();
    }
	

	void Update ()
    {
        // the projectile moves towards the last known location of the player
        if (ceva)
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //if it reaches that location without hitting the player, destroy it
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    // if the projectile hits the player, destroy it
    void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log(other.name);
        ceva = false;
        if (other.CompareTag("Player"))
            DestroyProjectile();

        if ( other.CompareTag("Shield"))
        {
            // vector between the player and projectile
            var dir = player.position - transform.position;
            // reflect the projectile vector, update "up" to where the player is facing
            var reflect = Vector2.Reflect(dir, player.up);
            rb.velocity = reflect * ReflectSpeed;
        }
    }

    // function that destroys the projectile
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
