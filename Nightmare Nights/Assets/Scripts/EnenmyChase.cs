using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyChase : MonoBehaviour
{
    public float aggroRange;
    public float moveSpeed;
    public float knockbackStrength;
    public int damageValue;
    public Transform mobHomeLocation;
    public Collider2D[] overlapColliders;
    private int playerLocationInArray;
    private bool isPlayerInRange;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        LookForPlayers();

        if (isPlayerInRange)
        {
            ChasePlayer();
        }
        if (!isPlayerInRange)
        {
            ReturnHome();
        }
    }

    public void LookForPlayers()
    {
        overlapColliders = Physics2D.OverlapCircleAll(transform.position, aggroRange);
        for (int i = 0; i < overlapColliders.Length; i++)
        {
            if (overlapColliders[i].CompareTag("Player"))
            {
                isPlayerInRange = true;
                playerLocationInArray = i;
                return;
            }
        }
        isPlayerInRange = false;
    }

    public void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, overlapColliders[playerLocationInArray].GetComponentInParent<Transform>().position, moveSpeed * Time.deltaTime);
    }

    public void ReturnHome()
    {
        transform.position = Vector2.MoveTowards(transform.position, mobHomeLocation.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 distance = other.transform.position - transform.position;
            other.gameObject.GetComponent<DungeonPlayerCharacter>().TakeDamage(damageValue);
            other.gameObject.GetComponent<DungeonPlayerCharacter>().StartKnockBack(KnockbackDirection(distance), knockbackStrength);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public Vector2 KnockbackDirection(Vector2 kb)
    {
        float x = 0;
        float y = 0;

        if (kb.x > 0)
        {
            x = 1;
        }
        else if (kb.x < 0)
        {
            x = -1;
        }
        else
        {
            x = 0;
        }

        if (kb.y > 0)
        {
            y = 1;
        }
        else if (kb.y < 0)
        {
            y = -1;
        }
        else
        {
            y = 0;
        }
        return new Vector2(x, y);


    }


}
