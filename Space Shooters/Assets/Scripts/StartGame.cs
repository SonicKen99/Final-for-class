using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public float timeLeft = 3;
    public Text TimeText;
    private bool timerIsActive = true;


    // Update is called once per frame
    void Update()
    {
        if (timerIsActive)
        {
        timeLeft -= Time.deltaTime;
        TimeText.text = (timeLeft).ToString("0");
            if (timeLeft <= 0)
            {
                timerIsActive = false;
            
            }
        }

    }
}
