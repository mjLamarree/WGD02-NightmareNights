using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSouth : MonoBehaviour
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
        if (GetComponentInParent<DungeonPlayerCharacter>().isPlayerSouth)
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
        anim.Play("SouthSlash");
    }
}
