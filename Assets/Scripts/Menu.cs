using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private bool soundOn = true;

    public Image soundImage;

    public Sprite soundOnIcon;
    public Sprite soundOffIcon;


    // Use this for initialization
    void Start () {
		
	}
    
    public void ToggleSound () {
        soundOn = !soundOn;
        if(soundOn)
        {
            soundImage.GetComponentInChildren<Image>().sprite = soundOnIcon;
        }
        else
        {
            soundImage.GetComponentInChildren<Image>().sprite = soundOffIcon;
        }
    }

    public void StartPressed ()
    {
        SceneManager.LoadScene("Main");
    }
}
