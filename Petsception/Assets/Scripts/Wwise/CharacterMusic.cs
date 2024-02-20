using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMusic : MonoBehaviour
{
    public AK.Wwise.Event MusicPlay;
    public AK.Wwise.Event DogEvent;
    public AK.Wwise.Event CatEvent;
    public AK.Wwise.Event ChameleonEvent;
    // Start is called before the first frame update
    void Start()
    {
        MusicPlay.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DogEvent.Post(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CatEvent.Post(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChameleonEvent.Post(gameObject);
        }

    }
}
