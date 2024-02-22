using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Pet
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D box;

    [SerializeField]
    private LayerMask ground;

    private Animator anim;
    private float dirX;

    public AK.Wwise.Event CatJump;
  
   
    // Start is called before the first frame update
    void Start()
    {
        //inControl = false;
       // Debug.Log("Cat control: " + inControl);
        rigidBody = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inControl == false)
        {
            return;
        }

        dirX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(dirX * movementSpeed, rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
            CatJump.Post(gameObject);
        }


        updateAnimationState();
    }

    public override void petAbility()
    {
       
    }

    public override void setInControl(bool newValue)
    {
        inControl = newValue;
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, ground);
    }

    private void updateAnimationState()
    {
        if (dirX > 0f)
        {
            transform.localScale = new Vector3(1,1,0);
            anim.SetBool("isMoving", true);
        }
        else if (dirX < 0f)
        {
            transform.localScale = new Vector3(-1,1, 0);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

       
    }
}
