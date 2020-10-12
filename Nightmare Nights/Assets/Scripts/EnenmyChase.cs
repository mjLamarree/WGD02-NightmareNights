using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyChase : EnemyData
{
    public Animator anim;

    private void Start()
    {
        SetUpReferences();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

        if (AmIDead())
        {
            StartCoroutine(DeathProcessing());
        }
        NearbyColliders();
        ChasePlayer();
        CheckDestination();
        if(isTakingDamage)
        {
            

            anim.SetBool("isTakingDamage", true);
        }
        else
        {
            anim.SetBool("isTakingDamage", false);
        }
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

    public void CheckDestination()
    {
        if(agent.hasPath == true)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

         if (transform.position == mobHome)
        {
            agent.ResetPath();
        }
    }

    public IEnumerator DeathProcessing()
    {
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);
    }


}
