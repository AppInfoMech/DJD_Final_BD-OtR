﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneStartTrigger : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("EndingCutscene");
        }
    }
}
