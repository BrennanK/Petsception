using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chameleon : Pet
{
    // Start is called before the first frame update
    void Start()
    {
        //inControl = false;
        Debug.Log("Chameleon control: " + inControl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void setInControl(bool newValue)
    {
        inControl = newValue;
    }

    public override void petAbility()
    {

    }
}
