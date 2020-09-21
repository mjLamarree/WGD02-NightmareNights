using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int sceneToSend;
    public GameObject sceneManager;
    public int count = 0;

    public void Awake()
    {
        sceneToSend = StaticVariables.sceneToLoad;
        Debug.Log(StaticVariables.sceneToLoad);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(count == 0)
        {
            
            if(sceneToSend <= 3)
            {
                StaticVariables.sceneToLoad = sceneToSend + 1;
                Debug.Log(StaticVariables.sceneToLoad);
                sceneManager.GetComponent<TransitionManger>().LoadScene(sceneToSend);

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        count = 0;
    }
}
