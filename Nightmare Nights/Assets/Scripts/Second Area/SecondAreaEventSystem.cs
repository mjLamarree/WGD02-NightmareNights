using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAreaEventSystem : MonoBehaviour
{

    public bool[] didPlayerTriggerEventAlready = {
        false,
        false,
        false,
        false
    };

    public int foutainsUsed = 0;
    public int obtainedKeys = 0;
    public static SecondAreaEventSystem current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onEncounterTrigger;
    public void TriggerEncounter(int id)
    {
        onEncounterTrigger?.Invoke(id);
    }

    public event Action onFountainTrigger;
    public void TriggerFountainEffect()
    {
        onFountainTrigger?.Invoke();
        didPlayerTriggerEventAlready[3] = false;
    }

}
