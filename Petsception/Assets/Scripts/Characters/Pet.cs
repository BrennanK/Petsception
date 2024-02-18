using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField]
    protected bool inControl; // bool used to determine which character the player has control off

    [SerializeField] protected float movementSpeed;
    [SerializeField] protected float jumpHeight;


    public virtual void petAbility()
    {

    }

    public virtual void setInControl(bool newValue)
    {
         inControl=newValue;
    }
}
