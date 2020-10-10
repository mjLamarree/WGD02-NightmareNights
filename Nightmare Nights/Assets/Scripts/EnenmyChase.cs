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
        if (AmIDead())
        {
            Destroy(gameObject);
        }
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
        agent.SetDestination(mobHome);
    }


}
