using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public enum States {
        ALIVE,
        DEAD
    }

    protected string characterName;
    protected int maxHealth;
    protected int currentHealth;
    protected States characterStates;

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
        characterStates = (currentHealth > 0) ? States.ALIVE : States.DEAD;
    }

    public void Heal(int recievedHealing)
    {
        currentHealth += recievedHealing;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

}
