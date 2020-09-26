using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int regenRate;
    private int damageCounter;
    private int regenCount;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    public void Update()
    {
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy Base") && regenCount == 0)
        {
            StartCoroutine("HealOverTime", regenRate);
            regenCount++;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy Base"))
        {
            StopCoroutine("HealOverTime");
            regenCount = 0;
        }

    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }

    public IEnumerator HealOverTime(int regenRate)
    {
        while (currentHP < maxHP)
        {
            yield return new WaitForSeconds(regenRate);
            currentHP += 1;
        }
        
    }

    public IEnumerator KnockedBack(Vector2 kbDirection, float multiplier)
    {
        
        rb.velocity = new Vector2(0, 0);
        Vector2 kbForce = new Vector2(kbDirection.x * multiplier, kbDirection.y * multiplier);
        rb.AddForce(kbForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.25f);
        rb.velocity = new Vector2(0, 0);
       
    }
    
    
}
