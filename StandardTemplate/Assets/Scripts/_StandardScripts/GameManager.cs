using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject errorMessage;
    public Text errorMessageText;
    private PlayData playData;
    public GameObject loadingScreen;
    public GameObject pausedMenu;
    public bool isGamePaused;
    public bool doesMouseLockOnStart = true;

    private void Start()
    {
        ToggleMouseOnOrOff(doesMouseLockOnStart);

        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "LevelSelection")
        {
            if (!AudioManager.instance.IsPlaying("MainMenuMusic"))
            {
                AudioManager.instance.Play("MainMenuMusic");
            }
            if (AudioManager.instance.IsPlaying("2DMusic"))
            {
                AudioManager.instance.Stop("2DMusic");
            }
            if (AudioManager.instance.IsPlaying("Music3D"))
            {
                AudioManager.instance.Stop("Music3D");
            }

        }
        else
        {
            AudioManager.instance.Stop("MainMenuMusic");

            if (!AudioManager.instance.IsPlaying("2DMusic"))
            {
                AudioManager.instance.Play("2DMusic");
                AudioManager.instance.GetSource("2DMusic").volume = 0f;
            }
            if (!AudioManager.instance.IsPlaying("Music3D"))
            {
                AudioManager.instance.Play("Music3D");
            }
        }

        playData = PlayData.instance;
        if (pausedMenu != null)
        {
            pausedMenu.SetActive(false);
            isGamePaused = false;
        }
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (pausedMenu != null)
        {
            if (!isGamePaused)
            {
                ToggleMouseOnOrOff(true);
                isGamePaused = true;
                pausedMenu.SetActive(true);
                Time.timeScale = 0;
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.Play("PauseScreenSFX");
                }
            }
            else
            {
                ToggleMouseOnOrOff(false);

                isGamePaused = false;
                pausedMenu.SetActive(false);
                Time.timeScale = 1;
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.Play("UnpauseSFX");
                    AudioManager.instance.Stop("PauseScreenSFX");
                }
            }
        }
    }

    public void GoToScene(Scene newScene)
    {
        GoToSceneName(newScene.ToString());
    }

    public void GoToSceneName(string SceneName)
    {
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("LoadingScreen");

            if (!AudioManager.instance.IsPlaying("MenuMusic"))
            {
                AudioManager.instance.Play("MenuMusic");
            }
        }

        SceneManager.LoadSceneAsync(SceneName);
    }

    public void SendErrorMessage(string newErrorMessage)
    {
        if (errorMessage != null)
        {
            errorMessageText.text = newErrorMessage;
            errorMessage.GetComponent<Animator>().SetTrigger("ErrorOccurred");
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play("HologramDeactivation");
            }
        }
        else
        {
            Debug.LogError(newErrorMessage);
        }

    }

    public void RestartScene()
    {
        GoToSceneName(SceneManager.GetActiveScene().name);
    }

    public void ToggleMouseOnOrOff(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = toggle;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
