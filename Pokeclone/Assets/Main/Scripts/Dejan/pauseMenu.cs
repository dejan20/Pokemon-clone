using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;   
    public static bool inventoryIsPaused = false;

    public GameObject inventoryMenuUI;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inventoryIsPaused)
            {
                Resume();
            }
            else
            {
                inventorymenu();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
               Pause();
            }
        }

    }

    void Resume ()
    {
        pauseMenuUI.SetActive(false);
        inventoryMenuUI.SetActive(false);
        inventoryIsPaused = false;
        GameIsPaused = false;

        Time.timeScale = 1f;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        inventoryMenuUI.SetActive(false);
        inventoryIsPaused = false;
    }

    void inventorymenu()
    {
            inventoryMenuUI.SetActive(true);
            Time.timeScale = 0f;
            inventoryIsPaused = true;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }
    public void ClickToHome()
    {
        SceneManager.LoadScene(2);
    }
}
