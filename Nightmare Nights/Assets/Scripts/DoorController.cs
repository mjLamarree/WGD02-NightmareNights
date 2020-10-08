using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public bool isDoorBlockedByEncounter = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Player" 
            && isDoorBlockedByEncounter == false
            && SecondAreaEventSystem.current.obtainedKeys == 3
            )
        {
            gameObject.SetActive(false);
        }

    }

}
