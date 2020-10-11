using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionCollider : MonoBehaviour
{

    [SerializeField] private GameObject transitionObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            Debug.Log("Collided with exit");
            collision.gameObject.GetComponent<DungeonPlayerCharacter>().canPlayerMove = false;
            StartTransitionAnimation();
        } 
    }

    private void StartTransitionAnimation(){
        transitionObject.SetActive(true);
        Animator transitionAnimator = transitionObject.GetComponent<Animator>();
        transitionAnimator.SetBool("transitionOut", true);
        transitionAnimator.SetBool("transitionIn", false);
    }

    private void WalkingDownStairsAnimation()
    {
        //Add Walking down stairs animation
    } 

}
