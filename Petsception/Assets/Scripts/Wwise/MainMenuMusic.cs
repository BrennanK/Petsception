using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public AK.Wwise.Event MainMenuMusicPlay;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuMusicPlay.Post(gameObject);
    }

    private void OnDestroy()
    {
        AkSoundEngine.StopAll(gameObject);
    }
}
