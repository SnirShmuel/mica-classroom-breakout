using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameGuideScript : MonoBehaviour
{
    public Text GuideText;
    public float fadeSpeed = 5;
    public bool isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        GuideText.color = new Color(255, 199, 87);
    }

    // Update is called once per frame
    void Update()
    {
        colorChange();
    }

    private void colorChange()
    {
        if (isTrigger)
        {
            GuideText.color = Color.Lerp(GuideText.color, new Color(255, 156, 49), fadeSpeed * Time.deltaTime);
        }
        else
        {
            GuideText.color = Color.Lerp(GuideText.color, Color.clear, fadeSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTrigger = false;
        }
    }

    
}
