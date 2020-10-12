using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyData
{
    public GameObject projectile;
    public float projectileSpeed;
    public bool canAttack = true;
    public Animator anim;

    void Start()
    {
        SetUpReferences();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AmIDead())
        {
            StartCoroutine(DeathProcessing());
        }
        NearbyColliders();
        FireProjectile();
        CheckDestination();
        if (isTakingDamage)
        {


            anim.SetBool("isTakingDamage", true);
        }
        else
        {
            anim.SetBool("isTakingDamage", false);
        }
    }

    public void FireProjectile()
    {
        if (isPlayerInRange && canAttack)
        {
            Instantiate(projectile, transform.position, Quaternion.identity, transform);
            StartCoroutine(AttackCooldownTimer());
            agent.SetDestination(nearbyColliders[playerLocationInArray].transform.position);
        }
        else if (!isPlayerInRange && canMove)
        {
            ReturnToHome();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<DungeonPlayerCharacter>().TakeDamage(damageDealt);
            Vector2 distance = new Vector2((other.transform.position.x - transform.position.x), (other.transform.position.y - transform.position.y));
            other.GetComponent<DungeonPlayerCharacter>().StartKnockBack(kbDir(distance,knockbackPower));
        }
    }

    public void ReturnToHome()
    {
        agent.SetDestination(mobHome);
    }

    public Vector2 GetTargetForProjectile()
    {
        Vector2 distance = new Vector2
             ((nearbyColliders[playerLocationInArray].transform.position.x - transform.position.x), (nearbyColliders[playerLocationInArray].transform.position.y - transform.position.y));
        //distance = KnockbackDirection(distance);
        distance = new Vector2(distance.x * projectileSpeed, distance.y * projectileSpeed);
        distance.x = Mathf.Clamp(distance.x, -projectileSpeed, projectileSpeed);
        distance.y = Mathf.Clamp(distance.y, -projectileSpeed, projectileSpeed);
        return distance;
    }

    public IEnumerator AttackCooldownTimer()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    public void CheckDestination()
    {
        if (agent.hasPath == true)
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
