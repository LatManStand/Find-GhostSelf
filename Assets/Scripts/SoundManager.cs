using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioMixer master;


    public Slider masterS;
    public Slider sfxS;
    public Slider musicS;


    public void ChangeMasterVolume()
    {
        master.SetFloat("Master", Mathf.Log(masterS.value) * 20);
    }
    public void ChangeSFXVolume()
    {
        master.SetFloat("SFX", Mathf.Log(sfxS.value) * 20);

    }
    public void ChangeMusicVolume()
    {
        master.SetFloat("Music", Mathf.Log(musicS.value) * 20);

    }


}
