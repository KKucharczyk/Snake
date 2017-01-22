using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour {

    public Text scoreText;

    // Use this for initialization
    void Start () {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("score");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
