using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    static public float currentTime;
    public int startMinutes;
    public TextMeshProUGUI currentTimeText;
    bool isTimerOver = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = PlayerPrefs.GetFloat("Timer", startMinutes * 60);
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
        }
        if (isTimerOver)
        {
            SceneManager.LoadScene("LoseMenuScene");
        }
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

}
