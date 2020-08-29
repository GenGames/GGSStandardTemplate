using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
	#region Singelton

	public static pauseMenu instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	#endregion

	public AudioMixer mainMixer;
	public Slider[] volumeSliders;
	public float[] currentVolumeSettings;
	public float minimumVolumeBeforeMute = -30;
	public float maximumVolume = 5;

	public Dropdown resolutionDropdown;

	Resolution[] resolutions;
	public int currentResolutionIndex;

	public bool isFullscreen = true;

	private void Start()
	{
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width &&
				resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
	}

	public void OnVolumeOpened()
	{
		mainMixer.GetFloat("masterVolume", out currentVolumeSettings[0]);
		mainMixer.GetFloat("musicVolume", out currentVolumeSettings[1]);
		mainMixer.GetFloat("sfxVolume", out currentVolumeSettings[2]);
		mainMixer.GetFloat("ambianceVolume", out currentVolumeSettings[3]);

		int i = 0;
		foreach (Slider slider in volumeSliders)
		{
			slider.minValue = minimumVolumeBeforeMute + .1f;
			slider.maxValue = maximumVolume;
			slider.value = currentVolumeSettings[i];
			i++;
		}
	}

	public void SetFullscreen(bool isNowFullscreen)
	{
		Screen.fullScreen = isNowFullscreen;
		isFullscreen = isNowFullscreen;
	}

	public void SetQuality (int qualityLevel)
	{
		QualitySettings.SetQualityLevel(qualityLevel);
	}

	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, isFullscreen);
	}

	public void EditVolume()
	{
		if (volumeSliders[0].value < minimumVolumeBeforeMute)
		{
			mainMixer.SetFloat("masterVolume", -80);
		}
		else
		{
			mainMixer.SetFloat("masterVolume", volumeSliders[0].value);
		}

		if (volumeSliders[1].value < minimumVolumeBeforeMute)
		{
			mainMixer.SetFloat("musicVolume", -80);
		}
		else
		{
			mainMixer.SetFloat("musicVolume", volumeSliders[1].value);
		}

		if (volumeSliders[2].value < minimumVolumeBeforeMute)
		{
			mainMixer.SetFloat("sfxVolume", -80);
		}
		else
		{
			mainMixer.SetFloat("sfxVolume", volumeSliders[2].value);
		}

		if (volumeSliders[3].value < minimumVolumeBeforeMute)
		{
			mainMixer.SetFloat("ambianceVolume", -80);
		}
		else
		{
			mainMixer.SetFloat("ambianceVolume", volumeSliders[3].value);
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
