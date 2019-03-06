using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour {

    private float timeBtwShots;
    public float startTimeBtwShots;

    public Transform firePoint;

    public GameObject projectile;

    int turretHP = 3;


    void Start ()
    {
        timeBtwShots = startTimeBtwShots;
    }
	
	
	void Update ()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, firePoint.position, Quaternion.identity);
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
            turretHP--;
            if (turretHP <= 0)
                Destroy(gameObject);
        }
    }
}
