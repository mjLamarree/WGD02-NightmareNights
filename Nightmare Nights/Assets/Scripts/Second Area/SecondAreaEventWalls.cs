using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecondAreaEventWalls : MonoBehaviour
{

    [SerializeField]
    private GameObject EncouonterWall;

    private void Start()
    {
        SecondAreaEventSystem.current.onEncounterTrigger += MakeWallsAppear;
    }

    private void MakeWallsAppear()
    {
        EncouonterWall.GetComponent<TilemapRenderer>().enabled = true;
        EncouonterWall.GetComponent<TilemapCollider2D>().enabled = true;
    }

    private void MakeWallsDisappear()
    {
        EncouonterWall.GetComponent<TilemapRenderer>().enabled = false;
        EncouonterWall.GetComponent<TilemapCollider2D>().enabled = false;
    }

}
