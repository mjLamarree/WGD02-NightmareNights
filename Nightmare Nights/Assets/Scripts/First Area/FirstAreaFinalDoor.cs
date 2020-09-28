using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FirstAreaFinalDoor : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(CheckForButtonPresses());
    }

    IEnumerator CheckForButtonPresses()
    {

        while (true)
        {

            if (FirstAreaEvents.current.buttonsPressed == 2)
            {
                gameObject.GetComponent<TilemapCollider2D>().enabled = false;
                gameObject.GetComponent<TilemapRenderer>().enabled = false;
                break;
            }

            yield return null;

        }

        yield return null;
        
    }

}
