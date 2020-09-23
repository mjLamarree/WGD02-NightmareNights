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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && damageCounter == 0)
        {
            TakeDamage(collision.GetComponent<WeaponScript>().damageDealt);
            damageCounter++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy Base"))
        {
            StopCoroutine("HealOverTime");
            regenCount = 0;
        }

        if (collision.CompareTag("Weapon"))
        {
            damageCounter = 0;
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
    
    
}
