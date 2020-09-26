using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPlayerCharacter : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 moveDirection;
    public Rigidbody2D rb;
    public float moveX;
    public float moveY;

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
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    public void MovePlayer()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }


}
