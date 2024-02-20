using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private Vector3 sitPosition;

    private Vector3 returnStartPosition;

    private float timePassed;

    [SerializeField] private float durationInSeconds;
    // Start is called before the first frame update
    void Start()
    {
        sitPosition = this.gameObject.transform.position;
        //StartCoroutine(goToTarget());
       // InvokeRepeating("callGoToTarget", Time.deltaTime, Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator goToTarget()
    {
        
        if(timePassed<durationInSeconds)
        {
            float t = timePassed / durationInSeconds;
            this.gameObject.transform.position = Vector3.Lerp(sitPosition, target.transform.position,t);
            timePassed += Time.deltaTime;
           // Debug.Log("We going");
            yield return null;
        }
        else 
        {
            timePassed = 0;
            CancelInvoke();
            // Debug.Log("We ended");
            returnStartPosition = this.transform.position;
            InvokeRepeating("callGoBack", Time.deltaTime, Time.deltaTime);
            yield return null;
        }
    }

    private void callGoToTarget()
    {
        StartCoroutine(goToTarget());
    }

    private void callGoBack()
    {
        StartCoroutine(goBack());
    }

    IEnumerator goBack()
    {
        if (timePassed < durationInSeconds)
        {
            float t = timePassed / durationInSeconds;
            this.gameObject.transform.position = Vector3.Lerp(returnStartPosition, sitPosition, t);
            timePassed += Time.deltaTime;
            //Debug.Log("We going");
            yield return null;
        }
        else
        {
            CancelInvoke();
            Debug.Log("We ended");
            yield return null;
        }
    }
}
