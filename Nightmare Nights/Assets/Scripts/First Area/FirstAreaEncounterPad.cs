using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAreaEncounterPad : MonoBehaviour
{

    bool didPlayerTriggerEvenAlready = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && didPlayerTriggerEvenAlready == false)
        {
            FirstAreaEvents.current.TriggerEncounter();
            didPlayerTriggerEvenAlready = true;
        }
    }

}
