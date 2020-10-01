using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionCollider : MonoBehaviour
{

    [SerializeField]
    private int sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition()
    {
        WalkingDownStairsAnimation();

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadSceneAsync(sceneIndex);

    }

    private void WalkingDownStairsAnimation()
    {
        //Add Walking down stairs animation
    } 

}
