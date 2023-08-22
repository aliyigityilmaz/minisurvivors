using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public GameObject StopMenu;
    public GameObject StopButton;
    private bool gamestopped;
    public GameObject LevelUpMenu;
    private GameObject player;
    private int beforeLevel;
    private int afterLevel;

    public AudioSource deathSound;
    public GameObject deathMenu;
    private bool playerdied = false;

    public Button button1, button2, button3;
    public bool sickleSelected, shovelSelected, harrowSelected = false;

    public AudioSource bgMusic;

    public GameObject winScreen;
    public AudioSource winSound;

    private float totaltime = 400f;
    private float timer;
    private int timerToint;
    public Text timerText;


    private void Awake()
    {

    }

    void Start()
    {
        winScreen.SetActive(false);
        deathMenu.SetActive(false);
        button1.enabled = true;
        button2.enabled = true;
        button3.enabled = true;
        player = GameObject.FindWithTag("Player");
        afterLevel = player.GetComponent<PlayerController>().playerLevel;
        Time.timeScale = 1.0f;
        StopMenu.SetActive(false);
        StopButton.SetActive(true);
        gamestopped = false;
        beforeLevel = afterLevel;
        LevelUpMenu.SetActive(false);
        timer = totaltime;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            timerToint = Convert.ToInt32(timer);
            timerText.text = "Survive until: " + timerToint.ToString();
        }
        else if (timer < 0)
        {
            Time.timeScale = 0f;
            winScreen.SetActive(true);
            winSound.Play();
        }

        if (player == null && playerdied == false)
        {
            Time.timeScale = 0f;
            deathMenu.SetActive(true);
            deathSound.Play();
            playerdied = true;
        }
        afterLevel = player.GetComponent<PlayerController>().playerLevel;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamestopped)
            {
                StopGame();
                gamestopped = true;
            }
            else if (gamestopped)
            {
                ResumeGame();
                gamestopped = false;
            }
        }
        if (afterLevel > beforeLevel)
        {
            Time.timeScale = 0f;
            LevelUpMenu.SetActive(true);
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        StopMenu.SetActive(true);
        StopButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        StopButton.SetActive(true);
        StopMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CloseLevelUp()
    {
        beforeLevel = afterLevel;
        LevelUpMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Choose1()
    {
        sickleSelected = true;
        button1.enabled = false;
        CloseLevelUp();
    }

    public void Choose2()
    {
        shovelSelected = true;
        button2.enabled = false;
        CloseLevelUp();
    }
    public void Choose3()
    {
        harrowSelected = true;
        button3.enabled = false;
        CloseLevelUp();
    }
}
