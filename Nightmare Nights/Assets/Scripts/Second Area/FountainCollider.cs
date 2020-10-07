using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainCollider : MonoBehaviour
{

    [SerializeField] private int id;
    [SerializeField] private int healingRecieved = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" 
            && collision.collider.GetComponent<DungeonPlayerCharacter>().currentHp != collision.collider.GetComponent<DungeonPlayerCharacter>().maxHp)
        {
            collision.collider.GetComponent<DungeonPlayerCharacter>().HealHealth(healingRecieved);
            transform.GetComponentInParent<FountainSwitcher>().SwitchFountain(id);
            SecondAreaEventSystem.current.foutainsUsed++;

            if(SecondAreaEventSystem.current.foutainsUsed >= 2)
            {
                SecondAreaEventSystem.current.TriggerEncounter(2);
                SecondAreaEventSystem.current.TriggerFountainEffect();
            }

        }
    }

}
