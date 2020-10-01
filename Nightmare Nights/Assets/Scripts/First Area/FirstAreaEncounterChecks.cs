using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FirstAreaEncounterChecks : MonoBehaviour
{

    public int id;

    [SerializeField]
    private GameObject Button;
    private Dictionary<int, GameObject> monstersRemaining = new Dictionary<int, GameObject>();

    private void Start()
    {
        if (Button != null) { DisableButton(Button); }
    }

    private void Update()
    {

        if (transform.childCount == 0)
        {
            DisableEncounterCheck();
            if (Button != null) { EnableButton(Button); }
            else { FirstAreaEvents.current.ButtonTrigger(); }
        }

    }

    void DisableEncounterCheck() {  this.gameObject.SetActive(false);  }

    private void DisableButton(GameObject Button)
    {
        Button.GetComponent<TilemapCollider2D>().enabled = false;
        Button.GetComponent<TilemapRenderer>().enabled = false;
    }

    private void EnableButton(GameObject Button)
    {
        Button.GetComponent<TilemapCollider2D>().enabled = true;
        Button.GetComponent<TilemapRenderer>().enabled = true;
    }

}
