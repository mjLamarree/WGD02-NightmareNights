using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseCircleTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("DungeonPlayer");
        player.GetComponent<DungeonPlayerCharacter>().canPlayerMove = false;
        StartCircleTransitionIn();
    }

    public void EndTransitionIn()
    {
        ResetCircleAnimationStates();
        Destroy(gameObject.GetComponent<InverseCircleTransition>());
        GameObject.Find("DungeonPlayer").GetComponent<DungeonPlayerCharacter>().canPlayerMove = true;
        gameObject.SetActive(false);
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

}
