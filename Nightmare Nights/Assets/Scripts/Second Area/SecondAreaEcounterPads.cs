using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAreaEcounterPads : MonoBehaviour
{

    public int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" 
            && SecondAreaEventSystem.current.didPlayerTriggerEventAlready[id-1] == false) {
            SecondAreaEventSystem.current.TriggerEncounter(id);
            SecondAreaEventSystem.current.didPlayerTriggerEventAlready[id-1] = true;
        }
    }

}
