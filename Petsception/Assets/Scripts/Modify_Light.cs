using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modify_Light : MonoBehaviour
{
    // Start is called before the first frame update
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
}
