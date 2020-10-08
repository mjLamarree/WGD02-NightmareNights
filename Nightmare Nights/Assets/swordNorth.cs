using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordNorth : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator anim;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sr.enabled = false;
    }



    void Update()
    {
        if (GetComponentInParent<DungeonPlayerCharacter>().isPlayerNorth)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }
    public void PlaySlashAnimation()
    {
        anim.Play("NorthSlash");
    }
}
