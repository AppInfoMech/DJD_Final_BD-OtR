using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialTimer : MonoBehaviour
{
    public GameObject Year;
    public GameObject Description;
    public GameObject continueButton;

    public bool tutDone = false;

    IEnumerator TutorialCoroutine()
    {
        while (tutDone == false)
        {
            yield return new WaitForSeconds(3.0f);
            Description.SetActive(true);
            tutDone = true;
        }

        while (tutDone == true)
        {
            yield return new WaitForSeconds(55f);
            continueButton.SetActive(true);
        }
       
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TutorialCoroutine());
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainGame");
    }
    
}
