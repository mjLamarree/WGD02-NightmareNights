using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapButton : MonoBehaviour
{

    public bool buttonWasPressed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        buttonWasPressed = true;
        Debug.Log("Something");
    }

}
