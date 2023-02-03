using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace SlimUI.ModernMenu{
	public class MainMenuNew : MonoBehaviour {
		Animator CameraObject;
/*
		[Header("Loaded Scene")]
		[Tooltip("The name of the scene in the build settings that will load")]
		public string sceneName = ""; 
*/
		public enum Theme {custom1, custom2, custom3};
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
		[Header("Menus")]
		[Tooltip("The Menu for when the MAIN menu buttons")]
		public GameObject mainMenu;
		[Tooltip("THe first list of buttons")]
		public GameObject OptionMenu;
		[Tooltip("The Menu for when the PLAY button is clicked")]
		public GameObject playMenu;
		[Tooltip("The Menu for when the EXIT button is clicked")]
		public GameObject exitMenu;

		void Start(){

			playMenu.SetActive(false);
			exitMenu.SetActive(false);
			OptionMenu.SetActive(false);
			mainMenu.SetActive(true);

			SetThemeColors();
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


		public void PlayGame(){
			exitMenu.SetActive(false);
			OptionMenu.SetActive(false);
			playMenu.SetActive(true);
			
		}
		

		public void ReturnMenu(){
			playMenu.SetActive(false);
			exitMenu.SetActive(false);
			OptionMenu.SetActive(false);
			mainMenu.SetActive(true);
		}
        /*
                public void NewGame(string){
                    if(sceneName != ""){
                        StartCoroutine(LoadAsynchronously(sceneName));
                    }
                }
        */


        public void Optionsetting(){
			playMenu.SetActive(false);
			exitMenu.SetActive(false);
			OptionMenu.SetActive(true);
		}

        // Are You Sure - Quit Panel Pop Up
        public void AreYouSure(){
			playMenu.SetActive(false);
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
		public void startScene()
		{
			SceneManager.LoadScene(1);
		}
	}
}