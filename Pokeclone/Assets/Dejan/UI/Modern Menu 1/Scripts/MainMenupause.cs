using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace SlimUI.ModernMenu{
	public class MainMenupause : MonoBehaviour 
	{

		Animator CameraObject;
		public enum Theme {custom1};
		[Header("Theme Settings")]
		public Theme theme;
		int themeIndex;
		public FlexibleUIData themeController;

		[Header("Panels")]
		[Tooltip("The UI Panel parenting all sub menus")]
		public GameObject mainCanvas;
		[Tooltip("The UI Panel that holds the CONTROLS window tab")]
		public GameObject PanelVideo;

		// campaign button sub menu
		public GameObject pauseMenu;
		public GameObject mainMenu;
		public GameObject OptionMenu;
		public GameObject ResumeMenu;
		public GameObject exitMenu;
		public bool GameIsPaused = false;



		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (GameIsPaused == true)
				{
					Resume();
				}
				else
                {
					pausemenu();
				}
			}

		}


		void Start(){

			ResumeMenu.SetActive(false);
			exitMenu.SetActive(false);
			OptionMenu.SetActive(false);
			mainMenu.SetActive(false);

			SetThemeColors();
		}
		void pausemenu()
        {
			Time.timeScale = 0f;
			GameIsPaused = true;
			ResumeMenu.SetActive(false);
			exitMenu.SetActive(false);
			OptionMenu.SetActive(false);
			mainMenu.SetActive(true);
		}

		void SetThemeColors()
		{
			if(theme == Theme.custom1)
			{
				themeController.currentColor = themeController.custom1.graphic1;
				themeController.textColor = themeController.custom1.text1;
				themeIndex = 0;
			}
		}

		public void Resume()
		{
			GameIsPaused = false;
			Time.timeScale = 1f;
			ResumeMenu.SetActive(false);
			exitMenu.SetActive(false);
			OptionMenu.SetActive(false);
			mainMenu.SetActive(false);
		}
		public void PlayGame(){
			
			Resume();

		}
		

		public void ReturnMenu(){
			ResumeMenu.SetActive(false);
			exitMenu.SetActive(false);
			OptionMenu.SetActive(false);
			mainMenu.SetActive(true);
		}

        public void Optionsetting(){
			ResumeMenu.SetActive(false);
			exitMenu.SetActive(false);
			OptionMenu.SetActive(true);
		}

        // Are You Sure - Quit Panel Pop Up
        public void AreYouSure(){
			ResumeMenu.SetActive(false);
			OptionMenu.SetActive(false);
			exitMenu.SetActive(true);
			
		}
		public void QuitGame(){
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}
	}
}