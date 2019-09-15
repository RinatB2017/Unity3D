using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bone : DebugClass
{
    // public Rigidbody2D bone;

    private bool f_moved = false;
    private float offset_x = 0f;
    private float offset_y = 0f;

    private Camera cam;

    void Awake()
    {
        cam = Camera.main;

        // Vector2 temp_vector = new Vector2(0, 0);
        // Instantiate(bone, temp_vector, Quaternion.identity);
    }


    void Update()
    {
#if UNITY_EDITOR
        Vector3 vp;
        if(Input.GetMouseButtonDown(0))
        {
            vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            offset_x = vp.x - gameObject.transform.position.x;
            offset_y = vp.y - gameObject.transform.position.y;
            // offset_x = vp.x - bone.transform.position.x;
            // offset_y = vp.y - bone.transform.position.y;
            f_moved = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            f_moved = false;
        }
        else if (Input.GetMouseButton(0))
        {
            if(f_moved)
            {
                vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                        Input.mousePosition.y, 
                                                        cam.nearClipPlane));
                vp.x -= offset_x;
                vp.y -= offset_y;
                gameObject.GetComponent<Rigidbody2D>().MovePosition(vp);
                // bone.MovePosition(vp);
            }
        }
#else
        Vector3 vp;
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    vp = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));
                    offset_x = vp.x - gameObject.transform.position.x;
                    offset_y = vp.y - gameObject.transform.position.y;
                    // offset_x = vp.x - bone.transform.position.x;
                    // offset_y = vp.y - bone.transform.position.y;
                    f_moved = true;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    if(f_moved)
                    {
                        vp = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));
                        vp.x -= offset_x;
                        vp.y -= offset_y;
                        gameObject.GetComponent<Rigidbody2D>().MovePosition(vp);
                        // bone.MovePosition(vp);
                    }
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    f_moved = false;
                    break;
            }
        }
#endif    
    }
}
