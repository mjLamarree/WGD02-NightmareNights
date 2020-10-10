using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFountainCollider : MonoBehaviour
{

    [SerializeField] private int healingRecieved = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player"
            && collision.collider.GetComponent<DungeonPlayerCharacter>().currentHp != collision.collider.GetComponent<DungeonPlayerCharacter>().maxHp)
        {
            collision.collider.GetComponent<DungeonPlayerCharacter>().HealHealth(healingRecieved);
            transform.parent.parent.GetComponent<BasicFountainAssetSwitcher>().SwitchFountainAsset();
        }

    }

}
