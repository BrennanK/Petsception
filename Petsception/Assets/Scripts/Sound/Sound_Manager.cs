using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sound_Manager : MonoBehaviour
{
    [SerializeField]
    private Slider audioSlider;

    [SerializeField]
    private AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", .4f);
            Load();
           // Debug.Log("Load from no pref: "+PlayerPrefs.GetFloat("musicVolume"));
        }
        else
        {
            Load();
           // Debug.Log("Load from pref: " + PlayerPrefs.GetFloat("musicVolume"));
        }
    }

    public void ChangeVolume()
    {
        backgroundMusic.volume = audioSlider.value;
        Save();
    }

    private void Load()
    {
        audioSlider.value = PlayerPrefs.GetFloat("musicVolume");
        backgroundMusic.volume = PlayerPrefs.GetFloat("musicVolume");
        
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", audioSlider.value);
        //Debug.Log("Save: " + PlayerPrefs.GetFloat("musicVolume"));
    }

}
