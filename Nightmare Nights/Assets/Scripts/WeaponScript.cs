using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public int damageDealt;
    public float knockbackMultipler;
    public GameObject Player;
    public Vector2 swingHitBoxSize;
    public Vector3 hitBoxOffset;

    //private Vector3 lastHitBoxPosition;
    private SpriteRenderer sr;
    public Collider2D[] overlapColliders;
    private bool hitBoxFlipped = false;
    private Animator anim;
    

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //lastHitBoxPosition = Player.GetComponent<Transform>().localPosition.normalized;
    }

    
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {

        }
        else
        {
            MoveHitBox();
        }
        
        CheckToFlipHitBox();
        if (Input.GetKeyDown(KeyCode.T))
        {
            AttackWithWeapon();
        }
    }


    public void AttackWithWeapon()
    {
        overlapColliders = Physics2D.OverlapBoxAll(transform.position, swingHitBoxSize, 0);
        for (int i = 0; i < overlapColliders.Length; i++)
        {
            if (overlapColliders[i].CompareTag("monster"))
            {
                overlapColliders[i].GetComponent<EnemyData>().TakeDamage(damageDealt);
                overlapColliders[i].GetComponent<EnemyData>().StartKnockBack(KnockbackDirection(), knockbackMultipler);
            }
            
        }
    }

    public void MoveHitBox()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 newHitBoxPosition = new Vector3(hitBoxOffset.x * moveX, hitBoxOffset.y * moveY, 0).normalized;
        transform.localPosition = newHitBoxPosition;
    }

    public void CheckToFlipHitBox()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && hitBoxFlipped)
        {
            FlipHitBox();
            hitBoxFlipped = false;
        }
        if (Input.GetAxisRaw("Vertical") != 0 && !hitBoxFlipped)
        {
            FlipHitBox();
        }
    }

    public void FlipHitBox()
    {
        float tempX = swingHitBoxSize.x;
        float tempY = swingHitBoxSize.y;
        swingHitBoxSize.x = tempY;
        swingHitBoxSize.y = tempX;
        hitBoxFlipped = true;

    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, swingHitBoxSize);        
    }
    
    public Vector2 KnockbackDirection()
    {
        float x = 0;
        float y = 0;
        if (transform.localPosition.x > 0)
        {
            x = 1;
        }
        else if(transform.localPosition.x < 0)
        {
            x = -1;
        }
        else
        {
            x = 0;
        }

        if(transform.localPosition.y > 0)
        {
            y = 1;
        }
        else if(transform.localPosition.y < 0)
        {
            y = -1;
        }
        else
        {
            y = 0;
        }

        return new Vector2(x, y);
        
    
    }

}
