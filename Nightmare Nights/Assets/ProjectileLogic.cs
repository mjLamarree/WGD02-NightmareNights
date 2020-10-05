using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    public int damageDealt;
    public float projectileSpeed;
    public int kbPower;
    public Vector2 projectileTarget;
    public bool canDamageSelf = false;
    public bool isFired = false;
    public GameObject player;
    public Rigidbody2D rb;
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        rb = GetComponent<Rigidbody2D>();
        projectileTarget = GetComponentInParent<EnemyRange>().GetTargetForProjectile();
        StartCoroutine("LaunchProjectile");
        StartCoroutine("SelfDestruct");

    }
    private void Update()
    {
        if (isFired == true)
        {
            TrackTarget(projectileTarget);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.collider.GetComponent<DungeonPlayerCharacter>().TakeDamage(damageDealt);
            Vector2 distance = new Vector2((transform.localPosition.x - other.transform.position.x), (transform.localPosition.y - other.transform.position.y));
            Destroy(gameObject); other.collider.GetComponent<DungeonPlayerCharacter>().StartKnockBack(KnockbackDirection(distance), kbPower);
            Destroy(gameObject);

        }
        else if (other.collider.CompareTag("monster"))
        {
            other.collider.GetComponent<EnemyData>().TakeDamage(damageDealt);
            Vector2 distance = new Vector2((other.transform.position.x - transform.localPosition.x), (other.transform.position.y - transform.localPosition.y));
            other.collider.GetComponent<EnemyData>().StartKnockBack(KnockbackDirection(distance), kbPower);            
            Destroy(gameObject);
        }
        else
        {
            
            Destroy(gameObject);
        }
    }

    public void TrackTarget(Vector2 target)
    {
        rb.velocity = target;
    }

    public IEnumerator LaunchProjectile()
    {
        isFired = true;
        yield return new WaitForSeconds(.2f);
        canDamageSelf = true;
    }

    public IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    public Vector2 KnockbackDirection(Vector2 kb)
    {
        float x = 0;
        float y = 0;

        if (kb.x > 0.2)
        {
            x = 1;
        }
        else if (kb.x < -0.2)
        {
            x = -1;
        }
        else
        {
            x = 0;
        }

        if (kb.y > 0.2)
        {
            y = 1;
        }
        else if (kb.y < -0.2)
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
