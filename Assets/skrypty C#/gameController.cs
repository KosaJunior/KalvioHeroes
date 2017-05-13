using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {

    public GameObject pause_panel, deadpanel;

    public Texture2D health;
    playerStats playerStat;

    // Use this for initialization
    void Start () {
        playerStat = GameObject.Find("Argo").GetComponent<playerStats>();
    }
	
	// Update is called once per frame
	void Update () {
        DeadMenu();

        if (Input.GetKeyDown("escape") && deadpanel.activeSelf == false)
        {
            TogglePauseMenu();
        }
	}

    public void TogglePauseMenu()
    {
        AudioSource[] audios = GameObject.FindObjectsOfType<AudioSource>();

        if (pause_panel.activeSelf == false)
        {
            foreach(AudioSource audio in audios)
            {
                audio.mute = true;
            }
            pause_panel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            foreach (AudioSource audio in audios)
            {
                audio.mute = false;
            }
            pause_panel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void DeadMenu()
    {
        if (playerStat.lives == 0)
        {
            deadpanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void OnGUI()
    {
        float healthX = 0;
        for (int i = 0; i < playerStat.lives; i++)
        {
            GUI.DrawTexture(new Rect(10 + healthX, 10, Screen.width * 0.1f, Screen.height * 0.1f), health, ScaleMode.ScaleToFit);
            healthX += 60;
        }
    }
}

