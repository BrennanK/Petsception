using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonFootSteps : MonoBehaviour
{
    public AK.Wwise.Event ChameleonFootStepSounds;
    public void ChameleonStepSoundPlay()
    {
        ChameleonFootStepSounds.Post(gameObject);
    }
}
