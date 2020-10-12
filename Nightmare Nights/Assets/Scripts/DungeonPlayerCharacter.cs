
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPlayerCharacter : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public float moveSpeed;
    private Vector2 moveDirection;
    public float moveX;
    public float moveY;
    public bool isPlayerMoving;
    public Vector2 playerDashPower;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;
    public AudioSource sounds;

    public AudioClip tookDamage;
    public AudioClip swungSword;

    public bool canPlayerMove = true;
    public bool canTakeDamage = true;
    private bool isPlayerDashing;

    public bool isPlayerNorth;
    public bool isPlayerSouth;
    public bool isPlayerEast;
    public bool isPlayerWest;
    public bool playerIsFacingDirection;
    public bool playerIsAttacking = false;


    private Vector2 controlVector = new Vector2(0,0);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sounds = GetComponent<AudioSource>();
    }
    public void Update()
    {
        GetPlayerInputs();
        PlayerDirection();
        ManageAnimations();
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

        public void HealHealth(int healthRecovered)
    {
        currentHp += healthRecovered;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
    }

    public void PlayerDied()
    {
        Destroy(gameObject);
    }

    public void StartKnockBack(Vector2 kb)
    {
        
        StartCoroutine(KnockedBack(kb));
    }

    public IEnumerator KnockedBack(Vector2 kbDirection)
    {
        if (canTakeDamage)
        {
            sounds.clip = tookDamage;
            sounds.Play();
            canPlayerMove = false;
            canTakeDamage = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(kbDirection, ForceMode2D.Impulse);
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
    public void PlayerDirection()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX > 0 && !playerIsAttacking)
        {
            isPlayerEast = true;
            isPlayerWest = false;
            isPlayerNorth = false;
            isPlayerSouth = false;
        }
        else if (moveX < 0  && !playerIsAttacking)
        {
            isPlayerEast = false;
            isPlayerWest = true;
            isPlayerNorth = false;
            isPlayerSouth = false;
        }
        else
        {

        }

        if (moveY > 0 && !playerIsAttacking )
        {
            isPlayerNorth = true;
            isPlayerSouth = false;
            isPlayerEast = false;
            isPlayerWest = false;
        }
        else if (moveY < 0 && !playerIsAttacking)
        {
            isPlayerNorth = false;
            isPlayerSouth = true;
            isPlayerEast = false;
            isPlayerWest = false;
        }
    }
    
    public void ManageAnimations()
    {
        if (isPlayerEast)
        {
            sr.flipX = false;
        }
        else if (isPlayerWest)
        {
            sr.flipX = true;
        }

        if (isPlayerMoving)
        {
            anim.SetBool("IsPlayerMoving", true);
        }
        else if (!isPlayerMoving)
        {
            anim.SetBool("IsPlayerMoving", false);
        }

        if (canTakeDamage)
        {
            anim.SetBool("canTakeDamage", true);
        }
        else if (!canTakeDamage)
        {
            anim.SetBool("canTakeDamage", false);
        }
       
    }

    public void ManageSounds()
    {
        if (!canTakeDamage)
        {
            sounds.clip = tookDamage;
            sounds.Play();
        }
        if (playerIsAttacking)
        {
            sounds.clip = swungSword;
            sounds.Play();
        }
    }

    public void StartStairs()
    {
        StartCoroutine(stairs());
    }

    public IEnumerator stairs()
    {
        yield return new WaitForSeconds(.7f);
        anim.Play("goingDownStairs");
    }

}

