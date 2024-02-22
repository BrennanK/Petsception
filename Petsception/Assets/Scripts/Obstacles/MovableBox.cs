using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBox : MonoBehaviour
{
    private bool catInBox;
    private Cat cat;
    private bool notTouchingGround;

    [SerializeField]
    private GameObject pushAbleBox;

    [SerializeField]
    private float pushAmount;

    [SerializeField]
    private LayerMask ground;

    [SerializeField]
    private BoxCollider2D detectionBox;

    [SerializeField]
    private float artificialGravity;

    private bool hasFallenOnce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Cat>())
        {
            //Debug.Log("We touched");
            catInBox = true;
            cat = collision.gameObject.GetComponent<Cat>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Cat>())
        {
            //Debug.Log("We touched");
            catInBox = false;
        }
    }

    private void Update()
    {
        Vector3 originalPosition = pushAbleBox.transform.position;
        if (!isGrounded())
        {
            pushAbleBox.transform.position = new Vector3(originalPosition.x, originalPosition.y - (Time.deltaTime * artificialGravity), originalPosition.z);
            hasFallenOnce = true;
        }


        if(catInBox && cat.getDirX()<0f&& cat.transform.position.y<=gameObject.transform.position.y && isGrounded())
        {
            originalPosition = pushAbleBox.transform.position;
            pushAbleBox.transform.position = new Vector3(originalPosition.x - (Time.deltaTime*pushAmount), originalPosition.y, originalPosition.z);
        }
    }

    private bool isGrounded()
    {
        Debug.Log("Ground Result: "+ (bool)Physics2D.BoxCast(detectionBox.bounds.center, detectionBox.bounds.size, 0f, Vector2.down, .1f, ground));
        //return Physics2D.BoxCast(detectionBox.bounds.center, detectionBox.bounds.size, 0f, Vector2.down, .1f, ground);

        RaycastHit2D[] items = Physics2D.BoxCastAll(detectionBox.bounds.center, detectionBox.bounds.size, 0f, Vector2.down, .01f, ground);

        if(items.Length>1)
        {
            if(hasFallenOnce)
            {
                detectionBox.offset = new Vector2(0, 0);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

}
