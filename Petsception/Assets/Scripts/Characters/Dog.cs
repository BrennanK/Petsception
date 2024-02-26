using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dog : Pet
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D box;

    [SerializeField]
    private LayerMask ground;

    private Animator anim;
    private float dirX;

    [SerializeField]
    private float abilityCoolodwnTime;

    private float timePassed;

    private bool onCooldown;

    [SerializeField]
    private float signalDuration;

    [SerializeField]
    private GameObject barkSignal;

    public GameEvent barkScareEvent;

    [SerializeField]
    private float scareTime;

    public AK.Wwise.Event DogJump;
    public AK.Wwise.Event DogBark;

    public float getCooldown()
    {
        return abilityCoolodwnTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        //inControl = true;
       // Debug.Log("Dog control: "+inControl);
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

       

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpHeight);
            DogJump.Post(gameObject);
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && onCooldown == false)
        {
            onCooldown = true;
            petAbility();
            DogBark.Post(gameObject);
        }

        updateAnimationState();
    }

    public override void petAbility()
    {
        Debug.Log("We barked");
        barkScareEvent.Raise(this, scareTime);
        barkSignal.SetActive(true);
        InvokeRepeating("coolDown", Time.deltaTime, Time.deltaTime);
    }

    private void coolDown()
    {
        timePassed += Time.deltaTime;
        if(timePassed>signalDuration)
        {
            barkSignal.SetActive(false);
        }
        if (timePassed > abilityCoolodwnTime)
        {
            onCooldown = false;
            CancelInvoke();
            timePassed = 0;
        }
    }

    public override void setInControl(bool newValue)
    {
        inControl=newValue;
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, ground);
    }

    private void updateAnimationState()
    {
        if (dirX > 0f)
        {
            transform.localScale = new Vector3(.6f, .6f, 0);
            anim.SetBool("isMoving", true);
        }
        else if (dirX < 0f)
        {
            transform.localScale = new Vector3(-.6f, .6f, 0);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if(isGrounded())
        {
            anim.SetBool("jumping", false);
        }
        else 
        {
            anim.SetBool("jumping", true);
        }
    }
}
