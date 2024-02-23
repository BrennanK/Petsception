using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintTrail : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<GameObject> prints;

    int i;

    [SerializeField]
    private float speedInSeconds;

    public AK.Wwise.Event ClimbPrintSound;

    void Start()
    {
        //startTrail();
    }

    private void performTrailVisual()
    {
        if(i<prints.Count)
        {
            prints[i].SetActive(true);
            ClimbPrintSound.Post(gameObject);
            i++;
        }
        else
        {
            for(int j=0;j<prints.Count;j++)
            {
                prints[j].SetActive(false);
                i = 0;
            }
        }
    }

    public void stopTrail()
    {
        for (int j = 0; j < prints.Count;j++)
        {
            prints[j].SetActive(false);
        }
        CancelInvoke();
    }

    public void startTrail()
    {
        InvokeRepeating("performTrailVisual", Time.deltaTime, speedInSeconds);
    }
    
    public void eventTrail(Component sender, object data)
    {
        bool whatToDo = (bool)data;

        if(whatToDo)
        {
            startTrail();
        }
        else
        {
            stopTrail();
        }
    }

    public void displayTrail(Component sender, object data)
    {
        if(data is Chameleon)
        {
            startTrail();
        }
        else
        {
            stopTrail();
        }
    }
}
