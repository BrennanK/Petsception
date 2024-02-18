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
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            isClimbable = false;
            isClimbing = false;
        }
    }
}
