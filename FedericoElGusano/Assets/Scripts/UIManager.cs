using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Start")]
    [SerializeField] private GameObject startMenu;
    [Header("Pause")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [Header("GameOver")]
    [SerializeField] private GameObject gameoverMenu;
    [Header("Settings")]
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private TMP_Dropdown settingsDropdown;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region pause
    public void ShowPauseMenu()
    {
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(1);
        startMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    #endregion
    public void DisableStart()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SetGameOver()
    {
        pauseButton.SetActive(false);
        gameoverMenu.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        gameoverMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
    }
    #region settings
    public void ChangeToSettings()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void ChangeToSettingsFromPause()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }
    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(settingsDropdown.value);
        PlayerPrefs.SetInt("Quality", settingsDropdown.value);

    }
    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    #endregion
}
