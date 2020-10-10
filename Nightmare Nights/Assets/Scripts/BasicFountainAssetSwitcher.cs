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

        /*for (int i = 0; i < blueFoutain.transform.childCount; i++)
        {
            blueFoutain.transform.GetChild(i).gameObject.SetActive(false);
        }*/

        redFountain.SetActive(true);
    }

}
