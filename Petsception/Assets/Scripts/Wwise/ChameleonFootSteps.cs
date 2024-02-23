using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonFootSteps : MonoBehaviour
{
    public AK.Wwise.Event ChameleonFootStepSounds;

    public float ChameleonYPosition;

    private Chameleon ChameleonScript; //Reference to the Chameleon Script

    private void Start()
    {
        ChameleonScript = GetComponent<Chameleon>();// Get a reference to Chameleon Script on the same game object
    }

    private void Update()
    {
        ChameleonYPosition = gameObject.transform.position.y;
    }
    public void ChameleonStepSoundPlay()
    {
        if (ChameleonScript.isGrounded())
        {
            ChameleonFootStepSounds.Post(gameObject);
        }
    }
}
