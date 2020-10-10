using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    
    public GameObject keySpotLight;

    [SerializeField] private int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            SecondAreaEventSystem.current.obtainedKeys++;
            SecondAreaEventSystem.current.TriggerEndEncounter(id);
            TurnOffKeyAsset();
            StartCoroutine(DeactivateWholeAsset());
        }

    }

    IEnumerator DeactivateWholeAsset()
    {
        StartLightFadeIn();
        yield return new WaitForSeconds(2.5f);
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    private void TurnOffKeyAsset()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    private void StartLightFadeIn()
    {
        Animator lightFadeIn = keySpotLight.GetComponent<Animator>();
        lightFadeIn.SetBool("keyWasGrabbed", true);
    }

}
