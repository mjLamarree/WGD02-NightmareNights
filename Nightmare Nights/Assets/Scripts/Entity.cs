using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public enum CharacterStates {
        ALIVE,
        DEAD
    }

    protected string characterName;
    protected int maxHealth;
    protected int currentHealth;

    public Entity(string characterName, int maxHealth, int currentHealth)
    {
        this.characterName = characterName;
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
    }

    public void TakeDamage(int recievedDamage)
    {
        currentHealth -= recievedDamage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

}
