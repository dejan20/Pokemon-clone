using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // De achtergrond van de menus
    public GameObject Background;

    // Dit zijn alle menus (aan functies) zodat de scripts ze makkelijk kunnen openen / sluiten (vooral nodig voor de DeathScreen)
    public GameObject beginMenu;
    public GameObject PauseMenu;
    public GameObject LevelSelectMenu;
    public GameObject SettingsMenu;

    public bool GamePaused = false;
    public bool PlayingGame = false;
    public bool GameFinished = false;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start()
    {
        // Dit is om de dropdown menu leeg te maken en de opties van welke resolutie(s) die je wel kan gebruiken te plaatsen
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }


    // ----- Om te checken per frame of er iets gebeurt -----

    void Update()
    {
        // Om de game te pauzeren als je op ESC klikt en enkel als het achtergrond inactief is (en dus geen andere menu open is)
        if (PlayingGame == true)
        {
            if (GamePaused == false)
            {
                if (GameFinished == false)
                {
                    if (Input.GetKeyDown(KeyCode.Escape)) // Als je op Esc klikt komt het pauze menu naar boven
                    {
                        Background.SetActive(true);
                        PauseMenu.SetActive(true);
                        Time.timeScale = 0f;
                        Debug.Log("Game paused");
                        GamePaused = true;
                    }
                }
            }
            else if (GamePaused == true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Background.SetActive(false);
                    PauseMenu.SetActive(false);
                    LevelSelectMenu.SetActive(false);
                    SettingsMenu.SetActive(false);
                    Time.timeScale = 1f;
                    GamePaused = false;
                    Debug.Log("Game unpaused");
                }
            }
        }
        
        if (GameFinished == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainMenuAfter");
                GameFinished = false;
                beginMenu.SetActive(true);
                Debug.Log("Returning to Main menu...");
            }
        }

        if (PlayingGame == false)
        {
            if (GameFinished == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    SettingsMenu.SetActive(false);
                    LevelSelectMenu.SetActive(false);
                    beginMenu.SetActive(true);
                }
            }
        }
    }

    // ----- Verschillende knop functies & startup setup -----

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void ResumePlay()
    {
        Time.timeScale = 1f;
        Debug.Log("Game unpaused");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level01");
        Debug.Log("Loading level 1...");
        Debug.Log("Entering PlayMode");
        Background.SetActive(false);
        PlayingGame = true;
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level02");
        Debug.Log("Loading level 2...");
        Debug.Log("Entering PlayMode");
        Background.SetActive(false);
        PlayingGame = true;
    }

    // General button functions again

    public void LeavingGame()
    {
        PlayingGame = false;
        GameFinished = false;
        Debug.Log("Exiting play mode");
    }

    public void QuitGame()
    {
        Debug.Log("Closing game...");
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restarting level...");
    }

    // Just the toggle to turn on/off fullscreen
    public void Fullscrn(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen is set to " + isFullscreen);
    }

    //Dit is voor de Graphics dropdown zodat je betere / mindere kwaliteit kan aanvinken met wat je wil spelen
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}