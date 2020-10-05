using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : WeaponScript
{
    public KeyCode attackKey;
    void Start()
    {
        SetUpReferences();
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
            AttackWithWeapon();
            StartCoroutine("PlaySwordAnimation");
            StartCoroutine("AttackCooldownTimer");
        }

    }

    public IEnumerator PlaySwordAnimation()
    {
        sr.gameObject.SetActive(true);
        anim.Play("SwordSlash");
        yield return new WaitForSeconds(0.7f);
        sr.gameObject.SetActive(false);
    }


}
