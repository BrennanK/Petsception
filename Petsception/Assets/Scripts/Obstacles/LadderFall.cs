using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderFall : MonoBehaviour
{

    [SerializeField]
    private GameObject ladderUpright;

    [SerializeField]
    private GameObject ladderFellOver;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Chameleon>())
        {
            ladderUpright.SetActive(false);
            ladderFellOver.SetActive(true);
        }
    }
}
