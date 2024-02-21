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

    private float delayForScare;
    // Start is called before the first frame update
    void Start()
    {
        sitPosition = this.gameObject.transform.position;
        returnStartPosition = sitPosition;
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
            this.gameObject.transform.position = Vector3.Lerp(returnStartPosition, target.transform.position,t);
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

    public void startFlight(Component sender, object data)
    {
        timePassed = 0;
        CancelInvoke();
        returnStartPosition= gameObject.transform.position;
        InvokeRepeating("callGoToTarget", Time.deltaTime, Time.deltaTime);
    }

    public void endFlight(Component sender, object data)
    {
        timePassed = 0;
        Debug.Log("We ended flight");
        CancelInvoke();
        returnStartPosition = gameObject.transform.position;
        InvokeRepeating("callGoBack", Time.deltaTime, Time.deltaTime);
        
        if(data is float)
        {
            Debug.Log("We got scared");
            delayForScare = (float)data;
            StartCoroutine(delayComeback());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("We should trigger");
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject==target)
        {
            target.gameObject.GetComponent<Chameleon>().setIsHit(true);
        }
        if(collision.gameObject.GetComponent<Cat>())
        {
            delayForScare = 3.0f;
            StartCoroutine(delayComeback());
        }
    }

    IEnumerator delayComeback()
    {
        yield return new WaitForSeconds(delayForScare);
        startFlight(this,true);

    }
}
