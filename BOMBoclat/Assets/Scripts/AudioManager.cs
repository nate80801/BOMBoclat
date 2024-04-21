// PUT THIS OBJECT AT THE MAIN MENU SCENE
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
    [Header("-----------Audio Source-----------")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;

    [Header("-----------Audio Clips-----------")]
    /*
    // background music
    public AudioClip Main_Menu;
    public AudioClip Level_1;
    public AudioClip Level_2;
    public AudioClip Level_3;
    */

    // sound effects
    public AudioClip Bomb_Explosion;
    public AudioClip Box_Breaking;
    public AudioClip Exit_Door;
    public AudioClip Player_Dying;
    public AudioClip Powerup;

    // starts automatically
    void Start()
    {
        // From SoundManager.cs in the main menu scene,
        // There will ALWAYS be a key in PlayerPrefs for musicVolume and sfx Volume
        musicSource.volume = PlayerPrefs.GetFloat("musicVolume");
        SFXSource.volume = PlayerPrefs.GetFloat("sfxVolume");

        Globals.AudioManagerObject = gameObject;
        // DontDestroyOnLoad(gameObject);
        // FIX: make sure audio loops

        /*
        musicSource.clip = Main_Menu; 
        musicSource.Play();  
        */
    }


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void ChangeBGM(AudioClip music)
    {
        musicSource.Stop();
        musicSource.clip = music;
        musicSource.Play();
    }

}
