using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AllPetGoal : MonoBehaviour
{
    private int numberOFPetsToWin;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            numberOFPetsToWin++;
        }

        if(numberOFPetsToWin==3)
        {
            Game_Manager.instance.solvedPuzzle();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            numberOFPetsToWin--;
        }
    }
}
