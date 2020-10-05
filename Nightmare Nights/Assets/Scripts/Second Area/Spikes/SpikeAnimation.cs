using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAnimation : MonoBehaviour
{

    private enum AnimationStates
    {
        Stage1,
        Stage2,
        Stage3,
        Stage4
    }

    [SerializeField]
    private float animationOffset;

    [SerializeField]
    private float animationInterval;

    private AnimationStates SpikeState;
    private GameObject[] spikeStages = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        GetSpikeStageObjects();
        StartCoroutine(StartSpikeStageCycle());
    }

    IEnumerator StartSpikeStageCycle()
    {

        yield return new WaitForSeconds(animationOffset);

        SpikeState = AnimationStates.Stage1;
        ToggleGameObjectOn((int)SpikeState);

        while (true) 
        { 
            yield return new WaitForSeconds(animationInterval);
            ToggleGameObjectOff((int)SpikeState);

            MoveToNextAnimationState();
            ToggleGameObjectOn((int)SpikeState);
        }

    }

    private void GetSpikeStageObjects()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            spikeStages[i] = transform.GetChild(i).gameObject;
        }
    }

    private void ToggleGameObjectOn(int index)
    {
        spikeStages[index].SetActive(true);
    }

    private void ToggleGameObjectOff(int index)
    {
        spikeStages[index].SetActive(false);
    }

    private void MoveToNextAnimationState()
    {

        switch (SpikeState)
        {
            case AnimationStates.Stage1:
                SpikeState = AnimationStates.Stage2;
                break;
            case AnimationStates.Stage2:
                SpikeState = AnimationStates.Stage3;
                break;
            case AnimationStates.Stage3:
                SpikeState = AnimationStates.Stage4;
                break;
            case AnimationStates.Stage4:
                SpikeState = AnimationStates.Stage1;
                break;
            default:
                SpikeState = AnimationStates.Stage1;
                break;
        }

    }

}
