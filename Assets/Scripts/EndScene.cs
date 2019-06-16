using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public GameObject endText;
    public GameObject textSound;
    public GameObject endButton;

    public bool endDone = false;

    IEnumerator EndCoroutine()
    {
        while(endDone == false)
        {
            yield return new WaitForSeconds(3.0f);
            endText.SetActive(true);
            textSound.SetActive(true);
            endDone = true;
        }

        while(endDone == true)
        {
            yield return new WaitForSeconds(7.5f);
            endButton.SetActive(true);
        }
    }

    void Start()
    {
        StartCoroutine(EndCoroutine());
    }

}
