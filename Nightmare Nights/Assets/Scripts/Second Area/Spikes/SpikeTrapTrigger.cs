using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class SpikeTrapTrigger : MonoBehaviour
{

    private enum TileStates
    {
        Stage1,
        Stage2,
        Stage3
    }

    private TileStates spikeStates;

    [SerializeField] private float trapInterval;
    [SerializeField] private GameObject button;
    [SerializeField] private Transform spikeTrapStageContainer;

    private void Awake()
    {
        spikeStates = TileStates.Stage1;
    }

    private void Update()
    {

        if (button.GetComponent<SpikeTrapButton>().buttonWasPressed)
        {
            button.GetComponent<SpikeTrapButton>().buttonWasPressed = false;
            StartCoroutine(ActivateTrap());
        }

    }

    private IEnumerator ActivateTrap()
    {

        ToggleOffUnpressedButton();

        SetCurrentSpikeStageToNonActive(spikeStates);
        spikeStates = NextState(spikeStates);
        SetCurrentSpikeStageToActive(spikeStates);

        yield return new WaitForSeconds(trapInterval);

        SetCurrentSpikeStageToNonActive(spikeStates);
        spikeStates = NextState(spikeStates);
        SetCurrentSpikeStageToActive(spikeStates);

        yield return new WaitForSeconds(2.0f);

        StartCoroutine(StartResettingTrapButton());
        SetCurrentSpikeStageToNonActive(spikeStates);
        spikeStates = NextState(spikeStates);
        SetCurrentSpikeStageToActive(spikeStates);

    }

    private IEnumerator StartResettingTrapButton()
    {
        yield return new WaitForSeconds(5.0f);
        ToggleOnUnpressedButton();
    }

    private void ToggleOnUnpressedButton()
    {
        button.gameObject.SetActive(true);
    }

    private void ToggleOffUnpressedButton()
    {
        button.gameObject.SetActive(false);
    }

    private void SetCurrentSpikeStageToNonActive(TileStates currentState)
    {
        switch (currentState)
        {
            case TileStates.Stage1:
                spikeTrapStageContainer.GetChild(0).gameObject.SetActive(false);
                break;
            case TileStates.Stage2:
                spikeTrapStageContainer.GetChild(1).gameObject.SetActive(false);
                break;
            case TileStates.Stage3:
                spikeTrapStageContainer.GetChild(2).gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    private void SetCurrentSpikeStageToActive(TileStates currentState)
    {
        switch (currentState)
        {
            case TileStates.Stage1:
                spikeTrapStageContainer.GetChild(0).gameObject.SetActive(true);
                break;
            case TileStates.Stage2:
                spikeTrapStageContainer.GetChild(1).gameObject.SetActive(true);
                break;
            case TileStates.Stage3:
                spikeTrapStageContainer.GetChild(2).gameObject.SetActive(true);
                break;
            default:
                break;
        }
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
                return TileStates.Stage1;
                break;
            default:
                return TileStates.Stage1;
                break;
        }
    }

}
