using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InverseCircleTransition : MonoBehaviour
{

    [SerializeField] private int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        StartCircleTransitionIn();
    }

    public void EndTransitionIn()
    {
        ResetCircleAnimationStates();
        //Destroy(gameObject.GetComponent<InverseCircleTransition>());
        //gameObject.SetActive(false);
    }

    private void StartCircleTransitionIn()
    {
        Animator transitionAnimator = gameObject.GetComponent<Animator>();
        transitionAnimator.SetBool("transitionOut", false);
        transitionAnimator.SetBool("transitionIn", true);
    }

    private void ResetCircleAnimationStates()
    {
        Animator transitionAnimator = gameObject.GetComponent<Animator>();
        transitionAnimator.SetBool("transitionOut", false);
        transitionAnimator.SetBool("transitionIn", false);
    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

}
