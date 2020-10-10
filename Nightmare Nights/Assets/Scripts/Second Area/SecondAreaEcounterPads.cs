using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAreaEcounterPads : MonoBehaviour
{

    public int id;

    private GameObject EncounterArea;

    private void Awake()
    {
        GameObject checkAreaParent = GameObject.Find("Encounters");

        for (int i = 0; i < checkAreaParent.transform.childCount; i++)
        {
            if (checkAreaParent.transform.GetChild(i).GetComponent<EncounterController>().id == id)
            {
                EncounterArea = checkAreaParent.transform.GetChild(i).gameObject;
                break;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" 
            && SecondAreaEventSystem.current.didPlayerTriggerEventAlready[id-1] == false) {
            SecondAreaEventSystem.current.TriggerEncounter(id);
            EncounterArea.SetActive(true);
            SecondAreaEventSystem.current.didPlayerTriggerEventAlready[id-1] = true;
        }
    }

}
