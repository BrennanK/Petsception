using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Pet
{
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        //inControl = false;
       // Debug.Log("Cat control: " + inControl);
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inControl == false)
        {
            return;
        }

        float dirX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(dirX * movementSpeed, rigidBody.velocity.y);


    }

    public override void petAbility()
    {
       
    }

    public override void setInControl(bool newValue)
    {
        inControl = newValue;
    }

   
}
