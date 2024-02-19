using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Pet
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D box;

    [SerializeField]
    private LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        //inControl = true;
       // Debug.Log("Dog control: "+inControl);
        rigidBody = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
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

        if (dirX > 0f)
        {
            transform.localScale = new Vector3(.6f, .6f, 0);
        }
        else if (dirX < 0f)
        {
            transform.localScale = new Vector3(-.6f, .6f, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpHeight);
        }
    }

    public override void petAbility()
    {
       
    }

    public override void setInControl(bool newValue)
    {
        inControl=newValue;
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, ground);
    }
}
