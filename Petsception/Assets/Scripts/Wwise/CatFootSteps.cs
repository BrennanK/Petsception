using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFootSteps : MonoBehaviour
{
    public AK.Wwise.Event CatFootStepSounds;
    public float CatYPosition;

    private void Update()
    {
        CatYPosition = gameObject.transform.position.y;
    }
    public void CatStepSoundPlay()
    {
        if (CatYPosition < -3.235)
        {
            CatFootStepSounds.Post(gameObject);
        }
    }
}
