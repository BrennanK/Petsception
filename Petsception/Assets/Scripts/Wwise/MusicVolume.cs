using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider SliderHandle;
    public float VolumeFloat;
    public AK.Wwise.RTPC VolumeRTPC;
    // Start is called before the first frame update
    void Awake()
    {
        VolumeFloat = 0.5f;
        VolumeRTPC.SetGlobalValue(VolumeFloat*100);
        SliderHandle.value = VolumeFloat;
    }

    // Update is called once per frame
    void Update()
    {
        VolumeRTPC.SetGlobalValue(VolumeFloat * 100);
        VolumeFloat = SliderHandle.value;
        
    }
}
