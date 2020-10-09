using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAreaEvents : MonoBehaviour
{

    public int buttonsPressed = 0;
    public bool isEncounterActive = false;
    public static FirstAreaEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onEncounterTrigger;
    public void TriggerEncounter()
    {
        onEncounterTrigger?.Invoke();
    }


    public event Action onButtonTrigger;
    public void ButtonTrigger()
    {
        onButtonTrigger?.Invoke();
    }
}
