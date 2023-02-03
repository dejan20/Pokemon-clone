using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace SlimUI.ModernMenu{
	public class OptionsMenuNew : MonoBehaviour {

		public enum Platform {Desktop, Mobile};
		public Platform platform;
		// toggle buttons

		[Header("VIDEO SETTINGS")]
		public GameObject fullscreentext;
		public GameObject musicSlider;



		public void Start()
		{
			// check slider values
			//musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");

			// check full screen
			if (Screen.fullScreen == true)
			{
				fullscreentext.GetComponent<TMP_Text>().text = "on";
			}
			else if (Screen.fullScreen == false)
			{
				fullscreentext.GetComponent<TMP_Text>().text = "off";
			}
		}

		public void Update()
		{
			//sliderValue = musicSlider.GetComponent<Slider>().value;
		}

		public void FullScreen (){
			Screen.fullScreen = !Screen.fullScreen;

			if(Screen.fullScreen == true){
				fullscreentext.GetComponent<TMP_Text>().text = "on";
			}
			else if(Screen.fullScreen == false){
				fullscreentext.GetComponent<TMP_Text>().text = "off";
			}
		}

		public void MusicSlider (){
			//PlayerPrefs.SetFloat("MusicVolume", sliderValue);
			PlayerPrefs.SetFloat("MusicVolume", musicSlider.GetComponent<Slider>().value);
		}
	}
}