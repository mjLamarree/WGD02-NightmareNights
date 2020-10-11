using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFountainAssetSwitcher : MonoBehaviour
{

    public GameObject blueFoutain;
    public GameObject redFountain;

    public void SwitchFountainAsset()
    {
        blueFoutain.SetActive(false);
        redFountain.SetActive(true);
    }

}
