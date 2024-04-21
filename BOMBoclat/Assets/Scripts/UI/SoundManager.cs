using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Debug.Log(audioManager);
        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else LoadMusic();

        if(!PlayerPrefs.HasKey("sfxVolume")){
            PlayerPrefs.SetFloat("sfxVolume", 1);
        }
        else LoadSFX();

        
    }

    public void ChangeMusicVolume(){
        //AudioListener.volume = musicSlider.value;
        audioManager.musicSource.volume = musicSlider.value;
        SaveMusic();
    }

    public void ChangeSFXVolume(){
        audioManager.SFXSource.volume = sfxSlider.value;
        SaveSFX();
    }

    public void LoadMusic(){
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void LoadSFX(){
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }
    

    public void SaveMusic(){
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
    public void SaveSFX(){
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
