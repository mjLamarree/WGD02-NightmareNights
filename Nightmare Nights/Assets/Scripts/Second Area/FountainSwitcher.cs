using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainSwitcher : MonoBehaviour
{

    public GameObject availableFountains;
    public GameObject nonAvailableFountains;

    public void SwitchFountain(int idIndex)
    {
        availableFountains.transform.GetChild(idIndex).gameObject.SetActive(false);
        nonAvailableFountains.transform.GetChild(idIndex).gameObject.SetActive(true);
    }

}
