using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFootSteps : MonoBehaviour
{
    public AK.Wwise.Event DogFootStepSounds;
    
    public float DogYPosition;

    private void Update()
    {
        DogYPosition = gameObject.transform.position.y;
    }

    public void PlayFootStepSound()
    {
        if (DogYPosition < -3.0)
        {
            DogFootStepSounds.Post(gameObject);
        }
        
    }
}
