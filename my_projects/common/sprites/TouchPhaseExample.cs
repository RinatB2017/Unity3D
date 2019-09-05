using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchPhaseExample : MonoBehaviour
{
    public Rigidbody2D gameObject;
    private bool f_moved = false;

    private Camera cam;
    private Vector3 old_pos;
    private Vector3 new_pos;

    private float x1 = 0f;
    private float y1 = 0f;
    private float x2 = 0f;
    private float y2 = 0f;

    void Awake()
    {
        cam = Camera.main;
        old_pos = new Vector3(0, 0, 0);
        new_pos = new Vector3(0, 0, 0);
    }

    private void move_pos()
    {
        if(f_moved)
        {
            if(old_pos != new_pos)
            {
                old_pos = new_pos;
                //gameObject.MovePosition(new_pos);
                gameObject.MovePosition(cam.ScreenToWorldPoint(new_pos));
            }

        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            print("Began");
            print(Input.mousePosition.x + ":" + Input.mousePosition.y);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            print("Ended");
            print(Input.mousePosition.x + ":" + Input.mousePosition.y);
        }
        else if (Input.GetMouseButton(0))
        {
            print("Moved");
            print(Input.mousePosition.x + ":" + Input.mousePosition.y);
        }
#else
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    print("Began");
                    print(touch.position.x + ":" + touch.position.y);

                    // x1 = gameObject.position.x;
                    // y1 = gameObject.position.y;
                    // x2 = x1 + gameObject.gameObject.transform.rect.width;

                    f_moved = true;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    print("Moved");
                    print(touch.position.x + ":" + touch.position.y);

                    new_pos.x = touch.position.x;
                    new_pos.y = touch.position.y;
                    move_pos();
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    print("Ended");
                    print(touch.position.x + ":" + touch.position.y);
                    f_moved = false;
                    break;
            }
        }
#endif            
    }
}
