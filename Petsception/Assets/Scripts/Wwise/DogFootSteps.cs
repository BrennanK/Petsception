using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFootSteps : MonoBehaviour
{
    public AK.Wwise.Event DogFootStepSounds;
    
    public float DogYPosition;

    private Dog DogScript;

    private void Start()
    {
        DogScript = GetComponent<Dog>();
    }

    private void Update()
    {
        DogYPosition = gameObject.transform.position.y;
    }

    public void PlayFootStepSound()
    {
        if (DogScript.isGrounded())
        {
            DogFootStepSounds.Post(gameObject);
        }
        
    }
}
