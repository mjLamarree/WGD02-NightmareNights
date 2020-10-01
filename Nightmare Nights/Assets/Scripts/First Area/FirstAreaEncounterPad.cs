using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAreaEncounterPad : MonoBehaviour
{

    public int id;

    private bool didPlayerTriggerEvenAlready = false;
    private GameObject checkArea; 

    private void Awake()
    {
        GameObject checkAreaParent = GameObject.Find("Encounter Checks");

        for(int i = 0; i < checkAreaParent.transform.childCount; i++)
        {
            if (checkAreaParent.transform.GetChild(i).GetComponent<FirstAreaEncounterChecks>().id == id)
            {
                checkArea = checkAreaParent.transform.GetChild(i).gameObject;
                Debug.Log(checkArea.name);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && didPlayerTriggerEvenAlready == false)
        {
            FirstAreaEvents.current.TriggerEncounter();
            checkArea.SetActive(true);
            didPlayerTriggerEvenAlready = true;
        }
    }

}
