using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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

    public Rigidbody2D rb;
    public Collider2D[] nearbyColliders;
    public NavMeshAgent agent;
    public int regenRate = 1;
    public bool isPlayerInRange;
    public int playerLocationInArray;
    public bool canMove = true;

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

    public void SetUpReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rb = GetComponent<Rigidbody2D>();
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

    public void StartKnockBack(Vector2 kbDir)
    {
        StartCoroutine(KnockedBack(kbDir));
    }
    public IEnumerator KnockedBack(Vector2 kbDirection)
    {      
            canMove = false;
            agent.isStopped = true;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(kbDirection, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.3f);
            rb.velocity = new Vector2(0, 0);
            canMove = true;
        agent.isStopped = false;
    }
    public Vector2 kbDir(Vector2 dir, int kbPower)
    {
        int intX;
        float floatX = 0;
        int intY;
        float floatY = 0;
        Vector2 bagool = new Vector2(0, 0);

        intX = (int)dir.x;
        if (intX >= 0 && intX != 1)
        {
            floatX = dir.x - intX;
        }
        else if (intX <= -0 && intX != -1)
        {
            intX = intX * -1;
            floatX = dir.x + intX;
        }
        else if (intX == 1)
        {
            bagool.x = 1;
        }
        else if (intX == -1)
        {
            bagool.x = -1;
        }
        else
        {
            bagool.x = 0;
        }

        if (floatX >= 0.10)
        {
            floatX += kbPower;
            bagool.x = floatX;

        }
        else if (floatX <= -0.10)
        {
            floatX -= kbPower;
            bagool.x = floatX;
        }
        //switch over too y
        intY = (int)dir.y;
        if (intY >= 0 && intY != 1)
        {
            floatY = dir.y - intY;
        }
        else if (intY <= -0 && intY != -1)
        {
            intY = intY * -1;
            floatY = dir.y + intY;
        }
        else if (intY == 1)
        {
            bagool.y = 1;
        }
        else if (intY == -1)
        {
            bagool.y = -1;
        }
        else
        {
            bagool.y = 0;
        }

        if (floatY >= 0.10)
        {
            floatY += kbPower;
            bagool.y = floatY;
        }
        else if (floatY <= -0.10)
        {
            floatY -= kbPower;
            bagool.y = floatY;
        }

        Debug.Log(bagool);

        return bagool;


    }
}
