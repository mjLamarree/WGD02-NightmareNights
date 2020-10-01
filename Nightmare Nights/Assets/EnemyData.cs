using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int moveSpeed;
    public int damageDealt;
    public int knockbackPower;
    public int attackCooldown;
    public float aggroRange;
    public Transform mobHome;

    public Collider2D[] nearbyColliders;
    public int regenRate = 1;
    public bool isPlayerInRange;
    public int playerLocationInArray;

    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
    }

    public void RestoreHealth(int restoreAmount)
    {
        if(currentHP < maxHP)
        {
            currentHP += Mathf.Clamp(restoreAmount, 1, maxHP - currentHP);
        }
    }

    public bool AmIDead()
    {
        if (currentHP <= 0 )
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void NearbyColliders()
    {
        nearbyColliders = Physics2D.OverlapCircleAll(transform.position, aggroRange);
        for (int i = 0; i < nearbyColliders.Length; i++)
        {
            if (nearbyColliders[i].CompareTag("Player"))
            {
                isPlayerInRange = true;
                playerLocationInArray = i;
                return;
            }
        }
        isPlayerInRange = false;
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
