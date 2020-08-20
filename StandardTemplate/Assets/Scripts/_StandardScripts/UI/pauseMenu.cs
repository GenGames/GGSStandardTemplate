using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
	public AudioMixer mainMixer;
	public Slider[] volumeSliders;
	public GameObject[] pauseMenuOptions;

	public void OpenMenu(int menuIndex)
	{
		for (int i = 0; i < pauseMenuOptions.Length; i++)
		{
			if (menuIndex == i)
			{
				pauseMenuOptions[i].SetActive(true);
			}
			else
			{
				pauseMenuOptions[i].SetActive(false);
			}
		}
	}

	public void EditVolume()
	{
		if (volumeSliders[0].value < -30)
		{
			mainMixer.SetFloat("masterVolume", -80);
		}
		else
		{
			mainMixer.SetFloat("masterVolume", volumeSliders[0].value);
		}

		if (volumeSliders[1].value < -30)
		{
			mainMixer.SetFloat("musicVolume", -80);
		}
		else
		{
			mainMixer.SetFloat("musicVolume", volumeSliders[1].value);
		}

		if (volumeSliders[2].value < -30)
		{
			mainMixer.SetFloat("sfxVolume", -80);
		}
		else
		{
			mainMixer.SetFloat("sfxVolume", volumeSliders[2].value);
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
