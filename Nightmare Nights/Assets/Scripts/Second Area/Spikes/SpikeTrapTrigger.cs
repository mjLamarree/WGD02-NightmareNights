using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpikeTrapTrigger : MonoBehaviour
{

    private enum TileStates
    {
        Stage1,
        Stage2,
        Stage3,
        Stage4
    }

    private bool buttonWasPressed;
    private TileStates spikeStates;

    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private GameObject spikeTrapStageContainer;

    void Start()
    {
        spikeStates = TileStates.Stage1;
        buttonWasPressed = buttonContainer.transform.GetChild(0).GetComponent<SpikeTrapButton>().buttonWasPressed;
    }

    void Update()
    {

        if (buttonWasPressed)
        {
            buttonWasPressed = !buttonWasPressed;
        }

    }

    private void ToggleOnUnpressedButton()
    {
        buttonContainer.transform.GetChild(0).gameObject.SetActive(true);
    }

    private TileStates NextState(TileStates currentState)
    {
        switch (currentState)
        {
            case TileStates.Stage1:
                return TileStates.Stage2;
                break;
            case TileStates.Stage2:
                return TileStates.Stage3;
                break;
            case TileStates.Stage3:
                return TileStates.Stage4;
                break;
            case TileStates.Stage4:
                return TileStates.Stage1;
                break;
            default:
                return TileStates.Stage1;
                break;
        }
    }

}
