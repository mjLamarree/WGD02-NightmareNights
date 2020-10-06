using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyChase : EnemyData
{


    private void Start()
    {
        SetUpReferences();
        rb = gameObject.GetComponent<Rigidbody2D>();   
    }
    private void Update()
    {
        AmIDead();
        NearbyColliders();
        ChasePlayer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<DungeonPlayerCharacter>().TakeDamage(damageDealt);
            Vector2 distance = new Vector2((other.transform.position.x - transform.position.x), (other.transform.position.y - transform.position.y));
            Debug.Log(distance);
            other.GetComponent<DungeonPlayerCharacter>().StartKnockBack(kbDir(distance, knockbackPower));
            
        }
    }

    public void ChasePlayer()
    {
        if (isPlayerInRange && canMove)
        {
            agent.SetDestination(nearbyColliders[playerLocationInArray].transform.position);           
        }
        else if (!isPlayerInRange && canMove)
        {           
            ReturnToHome();
        }
    }

    public void ReturnToHome()
    {
        agent.SetDestination(mobHome.position);
    }

    public Vector2 kbDir(Vector2 dir, int kbPower)
    {
        int intX;
        float floatX = 0;
        int intY;
        float floatY = 0;
        Vector2 bagool = new Vector2(0,0);

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
        else if(intX == 1)
        {
            bagool.x = 1;
        }
        else if(intX == -1)
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
        else if(floatY <= -0.10)
        {
            floatY -= kbPower;
            bagool.y = floatY;
        }
        
        Debug.Log(bagool);

        return bagool;


    }

}
