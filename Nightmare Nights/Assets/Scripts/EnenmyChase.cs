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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.collider.GetComponent<DungeonPlayerCharacter>().TakeDamage(damageDealt);
            Vector2 distance = new Vector2((other.transform.position.x - transform.position.x), (other.transform.position.y - transform.position.y));
            other.collider.GetComponent<DungeonPlayerCharacter>().StartKnockBack(KnockbackDirection(distance), knockbackPower);
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

}
