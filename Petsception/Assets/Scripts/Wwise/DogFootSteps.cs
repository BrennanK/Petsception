using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFootSteps : MonoBehaviour
{
    public AK.Wwise.Event DogFootStepSounds;
    public void PlayFootStepSound()
    {
        DogFootStepSounds.Post(gameObject);
    }
}
