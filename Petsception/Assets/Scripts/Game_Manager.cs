using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance { get; private set; }

    [SerializeField]
    float timeToSolveInSeconds;

    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private List<Pet> pets;

    [SerializeField]
    private Dog dog;

    [SerializeField]
    private Cat cat;

    [SerializeField]
    private Chameleon chameleon;

    public GameEvent gameEvent;

    [SerializeField]
    private GameObject gameOverMenu;

    private bool isGameOver;
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
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeToSolveInSeconds -= Time.deltaTime;
        updateTimer();

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Switch dog");
            gameEvent.Raise(this, dog);
            
            dog.setInControl(true);
            cat.setInControl(false);
            chameleon.setInControl(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Switch cat");
            gameEvent.Raise(this, cat);

            dog.setInControl(false);
            cat.setInControl(true);
            chameleon.setInControl(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Switch chameleon");
            gameEvent.Raise(this, chameleon);

            dog.setInControl(false);
            cat.setInControl(false);
            chameleon.setInControl(true);
        }
    }

    private void updateTimer()
    {
        int seconds = ((int)timeToSolveInSeconds % 60);
        int minutes = ((int)timeToSolveInSeconds / 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

        if(seconds==0 && minutes==0)
        {
            isGameOver = true;
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
        }
    }

    public bool getIsGameOver()
    {
        return isGameOver;
    }

    public void reloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
