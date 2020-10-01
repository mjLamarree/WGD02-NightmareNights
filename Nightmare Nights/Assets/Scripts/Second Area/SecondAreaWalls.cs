using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAreaWalls : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            Debug.Log("It works?" + gameObject.tag);
        }

    }

}
