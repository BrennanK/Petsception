using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chameleon : Pet
{
    private Rigidbody2D rigidBody;
    private Animator anim;

    private BoxCollider2D box;

    [SerializeField]
    private LayerMask ground;

    [SerializeField]
    private Color camoColor;

    private SpriteRenderer r;
    private Color originalColor;

    private bool isToggled;

    private bool canActivate;

    public void setCanActivate(bool newValue)
    {
        canActivate = newValue;
    }
    public bool getToggled()
    {
        return isToggled;
    }
    // Start is called before the first frame update

    public Animator getAnimator()
    {
        return anim;
    }
    void Start()
    {
        //inControl = false;
       // Debug.Log("Chameleon control: " + inControl);
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        canActivate = true;
        r = GetComponent<SpriteRenderer>();
        originalColor = r.color;
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

        if(dirX>0f)
        {
            transform.localScale=new Vector3(-.15f,.15f,0);
        }
        else if(dirX < 0f)
        {
            transform.localScale = new Vector3(.15f, .15f, 0);
        }

        if(Mathf.Abs(dirX)>0f)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            petAbility();
        }
    }

    public override void setInControl(bool newValue)
    {
        inControl = newValue;
    }

    public override void petAbility()
    {

        if(isToggled==true && canActivate==true)
        {
            isToggled = false;
            r.color = originalColor;
        }
        else if(isToggled == false && canActivate == true)
        {
            isToggled = true;
            r.color = camoColor;
        }

    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, ground);
    }

    public void toggleCamoAbility(Component sender, object data)
    {

        bool canBeActive = (bool)data;

        if(canBeActive)
        {
            canActivate = true;
        }
        else
        {
            
            if(isToggled)
            {
                petAbility();
            }
            canActivate = false;
        }
    }
}
