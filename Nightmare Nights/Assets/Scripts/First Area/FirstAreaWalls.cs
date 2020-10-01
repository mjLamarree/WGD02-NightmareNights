using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FirstAreaWalls : MonoBehaviour
{

    [SerializeField]
    private GameObject EncounterWall;

    private void Start()
    {
        FirstAreaEvents.current.onEncounterTrigger += MakeWallsAppear;
        FirstAreaEvents.current.onButtonTrigger += MakeWallsDisappear;
    }


    private void MakeWallsAppear()
    {
        EncounterWall.GetComponent<TilemapRenderer>().enabled = true;
        EncounterWall.GetComponent<TilemapCollider2D>().enabled = true;
    }

    private void MakeWallsDisappear()
    {
        EncounterWall.GetComponent<TilemapRenderer>().enabled = false;
        EncounterWall.GetComponent<TilemapCollider2D>().enabled = false;
    }
}
