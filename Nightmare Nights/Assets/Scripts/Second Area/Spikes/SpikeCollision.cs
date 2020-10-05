using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{

    [SerializeField]
    private int damageValue = 5;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            other.GetComponent<DungeonPlayerCharacter>().TakeDamage(damageValue);
        }
        
        if(other.tag == "monster")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damageValue);
        }

    }

}
