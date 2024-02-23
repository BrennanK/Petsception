using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CatFootSteps : MonoBehaviour
{
    
    public AK.Wwise.Event CatFootStepSounds;
    public float CatYPosition;
    private Cat CatScript;

    private void Start()
    {
        CatScript = GetComponent<Cat>();
    }
    private void Update()
    {
        CatYPosition = gameObject.transform.position.y;
    }
    

    public void CatStepSoundPlay()
    {
        if (CatScript.isGrounded())
        {
            CatFootStepSounds.Post(gameObject);
        }
    }
}
