using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    private float verticalDirection;

    [SerializeField]
    private float climbSpeed;

    private bool isClimbable;

    private bool isClimbing;

    private Rigidbody2D rigidBody;

    public GameEvent climbEvent;

    public GameEvent exitPoleArea;

    private bool onSurface;

    public bool getOnSurface()
    {
        return onSurface;
    }

    public bool getIsClimbable()
    {
        return isClimbable;
    }

    public void setIsClimabale(bool newValue)
    {
        isClimbable = newValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalDirection = Input.GetAxisRaw("Vertical");

        if(isClimbable && Mathf.Abs(verticalDirection) > 0f && gameObject.GetComponent<Chameleon>().getInControl())
        {
            isClimbing= true;
        }
    }

    private void FixedUpdate()
    {
        if(isClimbing)
        {
            rigidBody.gravityScale = 0f;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, verticalDirection * climbSpeed);
            setClimbRotation();
        }
        else
        {
            rigidBody.gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("We enetered Climb trigger");
        if(collision.CompareTag("Climbable"))
        {
            isClimbable = true;
            onSurface = true;
            climbEvent.Raise(this, gameObject.GetComponent<Chameleon>());
            //setClimbRotation();
            //this.gameObject.GetComponent<Chameleon>().getAnimator().SetBool("startClimb", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            isClimbable = false;
            onSurface = false;
            isClimbing = false;
            //this.gameObject.GetComponent<Chameleon>().getAnimator().SetBool("startClimb", false);
            resetRotation();
            exitPoleArea.Raise(this, 1);
            gameObject.GetComponent<Chameleon>().toggleCamoAbility(this, true);
        }
    }

    public void setClimbRotation()
    {
        //transform.Rotate(0,0,-90);
        if(verticalDirection==0)
        {
            return;
        }
        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,1),new Vector3(verticalDirection,0,0));
        if(verticalDirection<0)
        {
            transform.rotation=new Quaternion(transform.rotation.x, transform.rotation.y*-1, transform.rotation.z, transform.rotation.w);
        }
       // Debug.Log("This is new rotate: " + transform.rotation);
        //transform.rotation = new Quaternion(0, 0, -90, 0);
    }

    private void resetRotation()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,1), new Vector3(0, verticalDirection, 0));
        // transform.rotation = initialQuat;
    }
}
