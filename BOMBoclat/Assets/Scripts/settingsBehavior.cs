using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settingsBehavior : MonoBehaviour
{
    public Slider masterVol;
    public AudioMixer masterAudioMixer;
    public float masterFloat;
    public void changeMasterVolume()
    {
        masterAudioMixer.SetFloat("MasterVol", masterVol.value);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SaveSoundSettings()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}