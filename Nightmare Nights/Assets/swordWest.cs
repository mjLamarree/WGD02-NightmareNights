using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordWest : MonoBehaviour
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
        if (GetComponentInParent<DungeonPlayerCharacter>().isPlayerWest)
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
        anim.Play("WestSlash");
    }
}
