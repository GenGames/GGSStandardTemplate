using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

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
    private Keyboard keyboard;

    private void Start()
    {
        keyboard = InputSystem.GetDevice<Keyboard>();
        ToggleMouseOnOrOff(doesMouseLockOnStart);
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
        if (keyboard.escapeKey.wasPressedThisFrame)
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
            // Play sounds
            
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
