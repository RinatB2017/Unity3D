using UnityEngine;
using System.Collections;

public class TouchControls : DebugClass 
{
    public Rigidbody2D rigidbody2D;

    // GUI textures
    public GUITexture guiLeft;
    public GUITexture guiRight;
    public GUITexture guiJump;
    private Animator anim;
    // Movement variables
    public float moveSpeed = 5f;
    public float jumpForce = 50f;
    public float maxJumpVelocity = 2f;

    // Movement flags
    private bool moveLeft, moveRight, doJump = false;

    void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () 
    {
        // Check to see if the screen is being touched
        if (Input.touchCount > 0)
        {
            // Get the touch info
            Touch t = Input.GetTouch(0);

            // Did the touch action just begin?
            if (t.phase == TouchPhase.Began)
            {
                // Are we touching the left arrow?
                if (guiLeft.HitTest(t.position, Camera.main))
                {
                    Debug.Log("Touching Left Control");
                    moveLeft = true;
                }

                // Are we touching the right arrow?
                if (guiRight.HitTest(t.position, Camera.main))
                {
                    Debug.Log("Touching Right Control");
                    moveRight = true;
                }

                // Are we touching the jump button?
                if (guiJump.HitTest(t.position, Camera.main))
                {
                    Debug.Log("Touching Jump Control");
                    doJump = true;
                }
            }

            // Did the touch end?
            if (t.phase == TouchPhase.Ended)
            {
                // Stop all movement
                doJump = moveLeft = moveRight = false;
            }
        }

        // Is the left mouse button down?
        if (Input.GetMouseButtonDown(0))
        {
            // Are we clicking the left arrow?
            if (guiLeft.HitTest(Input.mousePosition, Camera.main))
            {
                Debug.Log("Touching Left Control");
                moveLeft = true;
            }

            // Are we clicking the right arrow?
            if (guiRight.HitTest(Input.mousePosition, Camera.main))
            {
                Debug.Log("Touching Right Control");
                moveRight = true;
            }

            // Are we clicking the jump button?
            if (guiJump.HitTest(Input.mousePosition, Camera.main))
            {
                Debug.Log("Touching Jump Control");
                doJump = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Stop all movement on left mouse button up
            doJump = moveLeft = moveRight = false;
        }
    }

    void FixedUpdate()
    {
        //anim.SetFloat("Speed", Mathf.Abs);
        // Set velocity based on our movement flags.
        if (moveLeft)
        {
            rigidbody2D.velocity = -Vector2.right * moveSpeed;
        }

        if (moveRight)
        {
            rigidbody2D.velocity = Vector2.right * moveSpeed;
        }

        if (doJump)
        {
            // If we have not reached the maximum jump velocity, keep applying force.
            if (rigidbody2D.velocity.y < maxJumpVelocity)
            {
                rigidbody2D.AddForce(Vector2.up * jumpForce);
            } else {
                // Otherwise stop jumping
                doJump = false;
            }
        }
    }
}
