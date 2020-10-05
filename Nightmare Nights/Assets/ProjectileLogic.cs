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
            Destroy(gameObject); other.collider.GetComponent<DungeonPlayerCharacter>().StartKnockBack(kbDir(distance,kbPower));
            Destroy(gameObject);

        }
        else if (other.collider.CompareTag("monster"))
        {
            other.collider.GetComponent<EnemyData>().TakeDamage(damageDealt);
            Vector2 distance = new Vector2((other.transform.position.x - transform.localPosition.x), (other.transform.position.y - transform.localPosition.y));
            other.collider.GetComponent<EnemyData>().StartKnockBack(kbDir(distance, kbPower));            
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
