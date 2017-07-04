using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPadScript : MonoBehaviour {

    public Text countdownText;
    public int timeToStay = 5;
    public string nextScene = "Next Scene";
    
    bool colliding;
    float countdown;

    private void Start()
    {
        countdown = timeToStay;
        countdownText = GameObject.Find("Level Countdown").GetComponent<Text>();
    }

    private void Update()
    {
        if (colliding)
        {
            countdown -= Time.deltaTime;
            countdownText.text = Math.Round(countdown, 0).ToString();
        }

        if (countdown < 0)
        {
            countdownText.enabled = false;
            enabled = false;
            GlobalSceneManager.SwitchScene(nextScene);
            Cursor.lockState = CursorLockMode.None;
            print("You Won!");
        }
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.tag != "Player")
            return;

        countdownText.text = countdown.ToString();
        countdownText.enabled = true;
        colliding = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag != "Player")
            return;

        countdown = timeToStay;
        countdownText.enabled = false;
        colliding = false;
    }
}
