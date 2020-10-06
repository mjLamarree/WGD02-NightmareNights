using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPlayerCharacter : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public float moveSpeed;
    private Vector2 moveDirection;
    public Rigidbody2D rb;
    public float moveX;
    public float moveY;
    public bool isPlayerMoving;
    public Vector2 playerDashPower;

    public bool canPlayerMove = true;
    public bool canTakeDamage = true;
    private bool isPlayerDashing;

    private Vector2 controlVector = new Vector2(0,0);

    public void Update()
    {
        GetPlayerInputs();
        if(currentHp <= 0)
        {
            PlayerDied();
        }
    }

    public void FixedUpdate()
    {
        if (canPlayerMove)
        {
            MovePlayer();
        }

        if (Input.GetKey(KeyCode.Q) && canPlayerMove)
        {
            PlayerDash();
        }
    }

    public void GetPlayerInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
        if((moveDirection.x != controlVector.x) || (moveDirection.y != controlVector.y))
        {
            isPlayerMoving = true;
        }
        else
        {
            isPlayerMoving = false;
        }
 
    }

    public void MovePlayer()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void PlayerDash()
    {
        if (isPlayerMoving)
        {

            StartCoroutine(IframesForDash());
            rb.AddForce(new Vector2(moveDirection.x * playerDashPower.x, moveDirection.y * playerDashPower.y), ForceMode2D.Impulse);

        }
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            currentHp -= damage;
            currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        }
        
    }

    public void PlayerDied()
    {
        Destroy(gameObject);
    }

    public void StartKnockBack(Vector2 kb, float power)
    {
        
        StartCoroutine(KnockedBack(kb, power));
    }

    public IEnumerator KnockedBack(Vector2 kbDirection, float multiplier)
    {
        if (canTakeDamage)
        {
            Debug.Log(kbDirection + "  " + multiplier);
            canPlayerMove = false;
            canTakeDamage = false;
            rb.velocity = new Vector2(0, 0);
            Vector2 kbForce = new Vector2(kbDirection.x * multiplier, kbDirection.y * multiplier);
            Debug.Log(kbForce);
            rb.AddForce(kbForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.3f);
            rb.velocity = new Vector2(0, 0);
            canTakeDamage = true;
            canPlayerMove = true;
        }

    }

    public IEnumerator IframesForDash()
    {
        isPlayerDashing = false;
        yield return new WaitForSeconds(.30f);
        isPlayerDashing = true;
                
    }

}
