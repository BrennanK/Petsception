using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMusic : MonoBehaviour
{
    public AK.Wwise.Event MusicPlay;
    public AK.Wwise.Event DogEvent;
    public AK.Wwise.Event CatEvent;
    public AK.Wwise.Event ChameleonEvent;
    //public AK.Wwise.Event BackgroundMusic;
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
            Debug.Log("1pressed");
            DogEvent.Post(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2pressed");
            CatEvent.Post(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChameleonEvent.Post(gameObject);
            Debug.Log("3pressed");
        }
        /*else
        {
            BackgroundMusic.Post(gameObject);
        }*/

    }

    private void OnDestroy()
    {
        AkSoundEngine.StopAll(gameObject);
    }
}
