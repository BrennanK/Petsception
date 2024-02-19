using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    //private bool canActivate;
    // Start is called before the first frame update
    private bool flipped;
    private bool canTrigger;
    [SerializeField]
    private float timeTillFlipBack;

    private float timePassed;

    [SerializeField]
    private Sprite unflippedSprite;

    [SerializeField]
    private Sprite flippedSprite;

    private SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        flipped = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && flipped == false && canTrigger==true)
        {
            Debug.Log("E pressed");
            flipped = true;
            sr.sprite = flippedSprite;
            InvokeRepeating("checkForFlipBack", Time.deltaTime, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Dog>()!=null)
        {
            canTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Dog>() != null)
        {
            canTrigger = false;
        }
    }

    private void checkForFlipBack()
    {
        if(timePassed>=timeTillFlipBack)
        {
            flipped = false;
            timePassed = 0;
            sr.sprite = unflippedSprite;
            CancelInvoke();
            return;
        }

        timePassed += Time.deltaTime;


    }
}
