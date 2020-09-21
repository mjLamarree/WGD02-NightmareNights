using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownPlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 moveDirection;
    public Rigidbody2D rb;

    public void Update()
    {
        GetPlayerInputs();    
    }

    public void FixedUpdate()
    {
        MovePlayer();
    }

    public void GetPlayerInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    public void MovePlayer()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
