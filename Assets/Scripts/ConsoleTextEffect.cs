using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ConsoleTextEffect : MonoBehaviour
{
    public float textDelay = 0.1f;
    public string textToShow;
    private string currentText = ""; 

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for(int i = 0; i < textToShow.Length; i++)
        {
            currentText = textToShow.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
    }
}
