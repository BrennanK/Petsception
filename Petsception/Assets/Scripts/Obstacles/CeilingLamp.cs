using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class CeilingLamp : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private List<Light2D> lights;

    [SerializeField]
    private float activeTime;

    private float timePassed;

    private bool flipped;

    private bool hasCat;

    private void Update()
    {
        if(flipped)
        {
            if(timePassed>activeTime)
            {
                flipped = false;
                timePassed = 0;
                toggleLights(0);
            }
            timePassed += Time.deltaTime;
            
        }

        if(!flipped && hasCat && Input.GetKeyDown(KeyCode.E))
        {
            flipped = true;
            toggleLights(1);
        }
    }

    private void toggleLights(float newValue)
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].intensity = newValue;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Cat>())
        {
            hasCat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Cat>())
        {
            hasCat = false;
        }
    }
}
