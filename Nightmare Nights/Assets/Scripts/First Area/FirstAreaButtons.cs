using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FirstAreaButtons : MonoBehaviour
{

    bool isButtonAlreadyPressed = false;

    public GameObject pressedButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player" && isButtonAlreadyPressed == false)
        {
            gameObject.GetComponent<TilemapCollider2D>().enabled = false;
            gameObject.GetComponent<TilemapRenderer>().enabled = false;

            pressedButton.GetComponent<TilemapRenderer>().enabled = true;

            FirstAreaEvents.current.ButtonTrigger();
            FirstAreaEvents.current.buttonsPressed++;

            isButtonAlreadyPressed = true;
        }

    }
}
