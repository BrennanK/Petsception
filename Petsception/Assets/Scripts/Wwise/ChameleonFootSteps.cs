using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonFootSteps : MonoBehaviour
{
    public AK.Wwise.Event ChameleonFootStepSounds;

    public float ChameleonYPosition;

    private void Update()
    {
        ChameleonYPosition = gameObject.transform.position.y;
    }
    public void ChameleonStepSoundPlay()
    {
        if (ChameleonYPosition < -3.616)
        {
            ChameleonFootStepSounds.Post(gameObject);
        }
    }
}
