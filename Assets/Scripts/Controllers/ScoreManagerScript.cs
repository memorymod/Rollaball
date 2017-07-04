using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour {

    public static Text scoreText;
    public static int score;

    private void Start()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        scoreText.text = "Score: " + score;
    }

    public static void CollectScore (int points)
    {
        score += points;

        scoreText.text = "Score: " + score;

    }
}
