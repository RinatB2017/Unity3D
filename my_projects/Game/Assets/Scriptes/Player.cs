using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera cam;
    private bool f_player = false;
    private float offset_x = 0f;
    private float offset_y = 0f;

    void Awake()
    {
        cam = Camera.main;
    }

    private void debug_print(string text)
    {
        print(text);
    }

    private bool analize(Vector3 vp)
    {
        float w = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        float h = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        float x = gameObject.transform.position.x - w / 2f;
        float y = gameObject.transform.position.y - h / 2f;
        Rect rect = new Rect(x,y,w,h);
        if (rect.Contains(vp))
        {
            debug_print("Yes!");
            debug_print(vp.x + ":" + vp.y);
            offset_x = vp.x - gameObject.transform.position.x;
            offset_y = vp.y - gameObject.transform.position.y;
            debug_print("offset: " + offset_x + ":" + offset_y);
            return true;
        }
        return false;
    }

    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            f_player = analize(vp);
        }
        else if (Input.GetMouseButtonUp(0))
        {

        }
        else if (Input.GetMouseButton(0))
        {
            if(f_player)
            {
                Vector3 vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                                Input.mousePosition.y, 
                                                                cam.nearClipPlane));
                vp.x -= offset_x;
                vp.y -= offset_y;
                gameObject.transform.position = vp;
            }
        }
#else
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 vp;

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    vp = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));
                    f_player = analize(vp);
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    if(f_player)
                    {
                        vp = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));
                        vp.x -= offset_x;
                        vp.y -= offset_y;
                        gameObject.transform.position = vp;
                    }
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    break;
            }
        }
#endif            
    }
}
