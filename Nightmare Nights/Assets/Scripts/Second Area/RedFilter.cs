using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedFilter : MonoBehaviour
{

    [SerializeField] private float maxOpacity = 0.125f;

    private void Start()
    {
        SecondAreaEventSystem.current.onFountainTrigger += MakeFilterAppear;
        gameObject.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f, 0.0f);
    }

    public void MakeFilterAppear()
    {
        gameObject.GetComponent<Image>().enabled = true;
        StartCoroutine(RaiseOpacity());
    }

    private IEnumerator RaiseOpacity()
    {

        float currentOpacity = 0.0f;

        while(currentOpacity <= maxOpacity)
        {
            currentOpacity += 0.005f;
            Debug.Log(currentOpacity);

            gameObject.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f, currentOpacity);

            yield return new WaitForSeconds(0.25f);
        }

    }

}
