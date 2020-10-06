using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAreaEventSystem : MonoBehaviour
{

    public int obtainedKeys = 0;
    public static SecondAreaEventSystem current;

    private void Awake()
    {
        current = this;
    }

    public event Action onEncounterTrigger;
    public void TriggerEncounter()
    {
        onEncounterTrigger?.Invoke();
    }

}
