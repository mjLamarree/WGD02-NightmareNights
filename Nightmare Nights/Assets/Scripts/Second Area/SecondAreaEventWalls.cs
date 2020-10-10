using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecondAreaEventWalls : MonoBehaviour
{

    public int id;

    [SerializeField]
    private GameObject EncouonterWall;

    private void Start()
    {
        SecondAreaEventSystem.current.onEncounterTrigger += MakeWallsAppear;
        SecondAreaEventSystem.current.onEncounterEndTrigger += MakeWallsDisappear;
    }

    private void MakeWallsAppear(int id)
    {
        if (id == this.id) { 
            EncouonterWall.GetComponent<TilemapRenderer>().enabled = true;
            EncouonterWall.GetComponent<TilemapCollider2D>().enabled = true;
        }
    }

    private void MakeWallsDisappear(int id)
    {
        if(id == this.id)
        {
            EncouonterWall.GetComponent<TilemapRenderer>().enabled = false;
            EncouonterWall.GetComponent<TilemapCollider2D>().enabled = false;
        }
    }

}
