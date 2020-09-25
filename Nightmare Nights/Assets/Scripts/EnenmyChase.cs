using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyChase : MonoBehaviour
{
    public float aggroRange;
    public float moveSpeed;
    public Transform mobHomeLocation;
    public Collider2D[] overlapColliders;
    private int playerLocationInArray;
    private bool isPlayerInRange;



    void Update()
    {

        LookForPlayers();

        if (isPlayerInRange)
        {
            ChasePlayer();
        }
        if (!isPlayerInRange)
        {
            ReturnHome();
        }
    }

    public void LookForPlayers()
    {
        overlapColliders = Physics2D.OverlapCircleAll(transform.position, aggroRange);
        for (int i = 0; i < overlapColliders.Length; i++)
        {
            if (overlapColliders[i].CompareTag("Player"))
            {
                isPlayerInRange = true;
                playerLocationInArray = i;
                return;
            }
        }
        isPlayerInRange = false;
    }

    public void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards
            (transform.position, overlapColliders[playerLocationInArray].GetComponentInParent<Transform>().position, moveSpeed * Time.deltaTime);
    }

    public void ReturnHome()
    {
        transform.position = 
            Vector2.MoveTowards(transform.position, mobHomeLocation.position, moveSpeed * Time.deltaTime);
    }


    

}
