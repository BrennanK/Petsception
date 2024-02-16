using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Pet
{
    // Start is called before the first frame update
    void Start()
    {
        //inControl = false;
        Debug.Log("Cat control: " + inControl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void petAbility()
    {
       
    }

    public override void setInControl(bool newValue)
    {
        inControl = newValue;
    }
}
