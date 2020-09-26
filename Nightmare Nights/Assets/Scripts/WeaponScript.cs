using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public int damageDealt;
    public int weaponSpeed;
    public GameObject Player;
    public Vector2 swingHitBoxSize;


    private Vector3 lastHitBoxPosition;
    public Collider2D[] overlapColliders;
    private bool hitBoxFlipped = false;
    private Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        lastHitBoxPosition = Player.GetComponent<Transform>().localPosition.normalized;
    }

    
    void Update()
    {
        MoveHitBox();
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
                overlapColliders[i].GetComponent<EnemyHealth>().TakeDamage(damageDealt);
            }
            
        }
    }
    public void MoveHitBox()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 offset = new Vector3(moveX,moveY, 0).normalized;

        lastHitBoxPosition = transform.localPosition + offset;
        transform.localPosition = new Vector3(Mathf.Clamp(lastHitBoxPosition.x,-1,1), Mathf.Clamp(lastHitBoxPosition.y,-1,1), 0).normalized;
       
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
    
}
