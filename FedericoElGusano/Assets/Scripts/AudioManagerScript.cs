using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [DoNotSerialize]public static AudioManagerScript instance;
    [Header("------------Audio Source --------------")]
    [SerializeField]AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------------Audio Clips -------------")]
    public AudioClip menuTheme;
    public AudioClip gameTheme;
    public AudioClip gameOverTheme;
    public AudioClip attack;
    public AudioClip jump;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);

        musicSource.volume = 0.35f;
        sfxSource.volume = 0.35f;
    }

    void Start()
    {
        musicSource.clip = menuTheme;
        musicSource.Play();
    }
    public void StartGame()
    {
        
        musicSource.Stop();
        musicSource.clip = gameTheme;
        musicSource.Play();
    }
    public void StartMenuTheme()
    {
        musicSource.Stop();
        musicSource.clip = menuTheme;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void StartGameOverTheme()
    {
        sfxSource.Stop();
        musicSource.clip = gameOverTheme;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip audio) {
        sfxSource.PlayOneShot(audio);
    }
}
