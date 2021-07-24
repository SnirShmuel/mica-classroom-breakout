using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    float currentTime;
    public int startMinutes;
    public TextMeshProUGUI currentTimeText;
    bool isTimerOver = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimerOver)
        {
            currentTime -= Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
        if (currentTime <= 0)
        {
            isTimerOver = true;
            SceneManager.LoadScene("LoseMenuScene");
        }
    }
}
