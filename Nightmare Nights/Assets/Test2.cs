using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private int sceneIndex = 0;
    private int count = 0;
    public GameObject levelManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(count == 0)
        {
            levelManager.GetComponent<TransitionManger>().LoadScene(sceneIndex);
            count++;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        count = 0;
    }
}
