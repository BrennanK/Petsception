using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance {get; private set;}

    [SerializeField]
    float timeToSolveInSeconds;

    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private List<Pet> pets;

    public GameEvent gameEvent;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance!=null && instance!=this)
        {
            Destroy(this);
        }
        else 
        {
            instance = this;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        timeToSolveInSeconds -= Time.deltaTime;
        updateTimer();

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Switch dog");
            gameEvent.Raise(this, pets[0]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Switch cat");
            gameEvent.Raise(this, pets[1]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Switch chameleon");
            gameEvent.Raise(this, pets[2]);
        }
    }

    private void updateTimer()
    {
        int seconds = ((int)timeToSolveInSeconds % 60);
        int minutes = ((int)timeToSolveInSeconds / 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

        if(seconds==0 && minutes==0)
        {
            //SceneManager.LoadScene(0);
        }
    }

    
}
