using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class Modify_Light : MonoBehaviour
{
    // Start is called before the first frame update

    public Light2D lightAffected;

    [SerializeField]private float catVisionLightIntensity;

    private float originalLightIntensity;
    private void Awake()
    {
        //lightAffected = GetComponent<Light2D>();
        originalLightIntensity = lightAffected.intensity;
    }
    public void DebugSender(Component sender, object data)
    {
        if(data is Dog)
        {
            Debug.Log("We are a dog");
        }

        if (data is Cat)
        {
            Debug.Log("We are a cat");
        }

        if(data is Chameleon)
        {
            Debug.Log("We are a chameleon");
        }
    }

    public void alterLightIntensity(Component sender, object data)
    {
        if (data is Dog)
        {
            lightAffected.intensity = originalLightIntensity;
        }

        if (data is Cat)
        {
            lightAffected.intensity = catVisionLightIntensity;
        }

        if (data is Chameleon)
        {
            lightAffected.intensity = originalLightIntensity;
        }
    }
}
