using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Start")]
    [SerializeField] public GameObject startMenu;
    [Header("Tutorial")]
    [SerializeField] public GameObject tutorial;
    [Header("Pause")]
    [SerializeField] public GameObject pauseMenu;
    public GameObject pauseButton;
    [Header("GameOver")]
    [SerializeField] public GameObject gameoverMenu;
    [Header("Settings")]
    [SerializeField] public GameObject settingsMenu;
    [Header("HUD")]
    [SerializeField] public GameObject hud;
    public HudManager hudManager;

    public TMP_Dropdown settingsDropdown;
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    // Start is called before the first frame update
    void Awake()
    {
        AudioSource[] audios = (AudioSource[])FindObjectsOfType(typeof(AudioSource));
        musicSource = audios[0];
        sfxSource = audios[1];
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        Time.timeScale = 0f;
        hudManager = hud.GetComponent<HudManager>();
    }
    private void Start()
    {
        musicSlider.value = musicSource.volume;
        sfxSlider.value = sfxSource.volume;
    }
    public void ChangeToShop()
    {
        SceneManager.LoadScene(2);
        Destroy(gameObject);
    }
    public void ReturnFromShop()
    {
        SceneManager.LoadScene(1);
        Destroy(gameObject);    
    }
    public void ChangeToArchivements()
    {
        SceneManager.LoadScene(3);
        Destroy(gameObject);
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
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        if (gameoverMenu.activeInHierarchy)
        {

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
        tutorial.SetActive(true);
    }
    public void StartGame()
    {
        tutorial.SetActive(false);
        pauseButton.SetActive(true);
        hud.SetActive(true);
        hudManager.RestoreHud();
        Time.timeScale = 1f;
    }
    public void SetGameOver()
    {
        pauseButton.SetActive(false);
        hud.SetActive(false);
        gameoverMenu.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        hud.SetActive(true);
        hudManager.RestoreHud();
        StartCoroutine(DesactivateGameOverUI());
    }
    IEnumerator DesactivateGameOverUI()
    {
        yield return 0;
        gameoverMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void JsonOrchestrator()
    {
        Shop shop = new Shop();
        Inventory inventory = new Inventory();
        string fileShop = "shop_items.data";
        string fileinventory = "inventory.data";

        try { inventory = Persistence.Load(fileinventory, inventory); }
        catch
        {
            inventory.coins = 0;
            inventory.armor = 0;
            inventory.weapon = 0;
            inventory.charge = 0;
            Persistence.Save(inventory, fileinventory);
        }

        try { shop = Persistence.Load(fileShop, shop); }
        catch
        {
            shop.shopItems = new ShopObject[10];
            shop.shopItems[0] = new ShopObject(1, 25, false);
            shop.shopItems[1] = new ShopObject(2, 100, true);
            shop.shopItems[2] = new ShopObject(3, 300, true);
            shop.shopItems[3] = new ShopObject(4, 50, false);
            shop.shopItems[4] = new ShopObject(5, 325, true);
            shop.shopItems[5] = new ShopObject(6, 600, true);
            shop.shopItems[6] = new ShopObject(7, 100, false);
            shop.shopItems[7] = new ShopObject(8, 350, true);
            shop.shopItems[8] = new ShopObject(9, 800, true);
            shop.coins = 1000;
            Persistence.Save(shop, fileShop);
        }
        shop.coins += inventory.coins;
        inventory.coins = 0;
        Persistence.Save(shop, fileShop);
        Persistence.Save(inventory, fileinventory);
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
        musicSource.volume = volume;
    }
    public void SetVolumeSounds(float volume)
    {
        sfxSource.volume = volume;
    }
    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(settingsDropdown.value);
        PlayerPrefs.SetInt("Quality", settingsDropdown.value);

    }
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void ResetValuesArchivement()
    {
        PlayerPrefs.SetInt("avanzar", 0);
        PlayerPrefs.SetInt("matar", 0);
        PlayerPrefs.SetInt("monedas", 0);
        PlayerPrefs.SetInt("muerte", 0);
        for (int i = 1; i < 4; i++)
        {
            PlayerPrefs.SetInt("avanzar" + i, 0);
            PlayerPrefs.SetInt("matar"+i, 0);
            PlayerPrefs.SetInt("monedas"+i, 0);
            PlayerPrefs.SetInt("muerte"+i, 0);
        }
    }
    #endregion
}