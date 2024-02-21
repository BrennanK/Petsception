using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFootSteps : MonoBehaviour
{
    public AK.Wwise.Event CatFootStepSounds;
    public void CatStepSoundPlay()
    {
        CatFootStepSounds.Post(gameObject);
    }
}
