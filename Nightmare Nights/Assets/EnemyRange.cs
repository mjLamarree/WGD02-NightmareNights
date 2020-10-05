using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyData
{
    public GameObject projectile;
    public float projectileSpeed;
    public bool canAttack = true;
    void Start()
    {
        SetUpReferences();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AmIDead();
        NearbyColliders();
        FireProjectile();
    }

    public void FireProjectile()
    {
        if (isPlayerInRange && canAttack)
        {
            Instantiate(projectile, transform.position, Quaternion.identity, transform);
            StartCoroutine(AttackCooldownTimer());
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
            Vector2 distance = new Vector2((other.transform.position.x - transform.position.x), (other.transform.position.y - transform.position.y));
            other.GetComponent<DungeonPlayerCharacter>().StartKnockBack(KnockbackDirection(distance), knockbackPower);
        }
    }

    public void ReturnToHome()
    {
        agent.SetDestination(mobHome.position);
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
}
