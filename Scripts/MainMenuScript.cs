using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject creditsMenu;
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenCreditsMenu()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void CloseCreditsMenu()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
