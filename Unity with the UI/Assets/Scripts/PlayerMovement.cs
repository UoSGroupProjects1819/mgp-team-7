using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        FaceMouse();

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
	}

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
