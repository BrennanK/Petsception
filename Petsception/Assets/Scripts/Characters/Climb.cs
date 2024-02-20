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

    private Quaternion initialQuat;

    public bool getIsClimbable()
    {
        return isClimbable;
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        initialQuat = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        verticalDirection = Input.GetAxisRaw("Vertical");

        if(isClimbable && Mathf.Abs(verticalDirection) > 0f)
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
        }
        else
        {
            rigidBody.gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("We enetered Climb trigger");
        if(collision.CompareTag("Climbable"))
        {
            isClimbable = true;
            //setClimbRotation();
            //this.gameObject.GetComponent<Chameleon>().getAnimator().SetBool("startClimb", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            isClimbable = false;
            isClimbing = false;
            //this.gameObject.GetComponent<Chameleon>().getAnimator().SetBool("startClimb", false);
            //resetRotation(270);
        }
    }

    public void setClimbRotation()
    {
        transform.Rotate(0,0,-90);
        //transform.rotation = new Quaternion(0, 0, -90, 0);
    }

    private void resetRotation(float degrees)
    {
        transform.Rotate(0, 0, degrees);
       // transform.rotation = initialQuat;
    }
}
