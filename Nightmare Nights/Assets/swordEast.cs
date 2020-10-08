using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordEast : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator anim;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (GetComponentInParent<DungeonPlayerCharacter>().isPlayerEast)
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
        anim.Play("EastSlash");
    }
}
