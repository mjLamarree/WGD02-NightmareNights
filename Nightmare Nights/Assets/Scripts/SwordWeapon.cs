using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : WeaponScript
{
    public KeyCode attackKey;
    public GameObject swordNorth;
    public GameObject swordSouth;
    public GameObject swordEast;
    public GameObject swordWest;
    private AudioSource sound;

    void Start()
    {
        SetUpReferences();
        sound = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (CheckToMoveHitBox())
        {
            MoveHitBox();
        }
        CheckToFlipHitBox();
        if (Input.GetKeyDown(attackKey) && canAttack)
        {
            sound.Play();
            AttackWithWeapon();
            StartCoroutine("PlaySwordAnimation");
            StartCoroutine("AttackCooldownTimer");
        }

    }

    public IEnumerator PlaySwordAnimation()
    {
        if (GetComponentInParent<DungeonPlayerCharacter>().isPlayerWest)
        {
            swordWest.GetComponent<swordWest>().PlaySlashAnimation();
        }
        else if (GetComponentInParent<DungeonPlayerCharacter>().isPlayerSouth)
        {
            swordSouth.GetComponent<swordSouth>().PlaySlashAnimation();
        }
        else if (GetComponentInParent<DungeonPlayerCharacter>().isPlayerNorth)
        {
            swordNorth.GetComponent<swordNorth>().PlaySlashAnimation();
        }
        else if (GetComponentInParent<DungeonPlayerCharacter>().isPlayerEast)
        {
            swordEast.GetComponent<swordEast>().PlaySlashAnimation();
        }
            yield return new WaitForSeconds(0.7f);
    }



}
