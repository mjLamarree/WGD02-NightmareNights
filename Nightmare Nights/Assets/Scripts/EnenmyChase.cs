using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyChase : EnemyData
{
    public Rigidbody2D rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();   
    }
    private void Update()
    {
        AmIDead();
        NearbyColliders();
    }

    public void ChasePlayer()
    {
        if (isPlayerInRange)
        {

        }
    }

}
