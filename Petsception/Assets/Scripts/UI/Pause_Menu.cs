using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause_Menu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Game_Manager.instance.getIsGameOver()==false)
        {
            paused = !paused;

            if(paused)
            {
                activatePause();
            }
            else
            {
                deactivatePause();
            }
        }
    }

    private void activatePause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void deactivatePause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        paused = false;
    }

    public void QuitLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
