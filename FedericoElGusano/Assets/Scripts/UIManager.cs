using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public static UIManager instance;
    [Header("Start")]
    [SerializeField] public GameObject startMenu;
    [Header("Pause")]
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject pauseButton;
    [Header("GameOver")]
    [SerializeField] public GameObject gameoverMenu;
    [Header("Settings")]
    [SerializeField] public GameObject settingsMenu;
    [SerializeField] public TMP_Dropdown settingsDropdown;
    [SerializeField] public GameObject parallax;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Awake()
    {
        /*if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);*/

        Time.timeScale = 0f;
    }

    public void ChangeToShop()
    {
        SceneManager.LoadScene(2);
        StartCoroutine(DesactivateParallax());
        
    }
    IEnumerator DesactivateParallax()
    {
        yield return new WaitForSeconds(2);
        parallax.SetActive(false);
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
    public void ReturnFromShop()
    {
        SceneManager.LoadScene(1);
        StartCoroutine(ActivateParallax());
        
        
    }
    IEnumerator ActivateParallax()
    {
        yield return new WaitForSeconds(2);
        parallax.SetActive(true);
    }
    public void ReturnMenu()
    {
        
        SceneManager.LoadScene(1);
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        if (gameoverMenu.activeInHierarchy) {

            StartCoroutine(DesactivateGO());
        }

    }
    IEnumerator DesactivateGO()
    {
        yield return 0;
        gameoverMenu.SetActive(false);
    }
    #endregion
    public void DisableStart()
    {
        startMenu.SetActive(false);
        pauseButton.SetActive(true);
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
        StartCoroutine(DesactivateGameOverUI());
    }
    IEnumerator DesactivateGameOverUI()
    {
        yield return 0;
        gameoverMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
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
