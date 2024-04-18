// PUT THIS OBJECT AT THE MAIN MENU SCENE
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
    [Header("-----------Audio Source-----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----------Audio Clips-----------")]
    // background music
    public AudioClip Main_Menu;
    public AudioClip Gameplay;

    // sound effects
    public AudioClip Bomb_Explosion;
    public AudioClip Box_Breaking;
    public AudioClip Exit_Door;
    public AudioClip Player_Dying;
    public AudioClip Powerup;
    public AudioClip Victory;

    // starts automatically
    void Start()
    {
        Globals.AudioManagerObject = gameObject;
        DontDestroyOnLoad(gameObject);
        // FIX: make sure audio loops

        musicSource.clip = Main_Menu; 
        musicSource.Play();  
    }


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip song){
        musicSource.clip = song;
        musicSource.Play();
    }


}
