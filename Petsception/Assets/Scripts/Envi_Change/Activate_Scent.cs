using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Scent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ParticleSystem scent;

    public void toggleScentParticle(Component sender, object data)
    {
        if(data is Dog)
        {
            scent.Play();
        }
        else
        {
            scent.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}
