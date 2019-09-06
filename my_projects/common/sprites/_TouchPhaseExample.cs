using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPhaseExample : MonoBehaviour
{
    private enum States 
	{ 
		NONE, BEGAN, ENDED, MOVED
	};
    private States state = States.NONE;

    public List<GameObject> l_obj;

    private int index = -1;
    private float offset_x = 0f;
    private float offset_y = 0f;

    private Camera cam;

    private void debug_print(string text)
    {
        print(text);
    }

    void Awake()
    {
        cam = Camera.main;

        for(int i=0; i<l_obj.Count; i++)
        {
            float x = l_obj[i].transform.position.x;
            float y = l_obj[i].transform.position.y;
            float width  = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.x;
            float height = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.y;
            debug_print("Mace: " + x + ":" + y + " " + width + ":" + height);
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            state = States.BEGAN;
            Vector3 wp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

            for(int i=0; i<l_obj.Count; i++)
            {
                float w = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.x;
                float h = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.y;
                float x = l_obj[i].transform.position.x - w / 2f;
                float y = l_obj[i].transform.position.y - h / 2f;
                Rect rect = new Rect(x,y,w,h);
                if (rect.Contains(wp))
                {
                    debug_print("Yes! " + i);
                    debug_print(wp.x + ":" + wp.y);
                    offset_x = wp.x - l_obj[i].transform.position.x;
                    offset_y = wp.y - l_obj[i].transform.position.y;
                    debug_print("offset: " + offset_x + ":" + offset_y);
                    index = i;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            state = States.ENDED;
            index = -1;
        }
        else if (Input.GetMouseButton(0))
        {
            state = States.MOVED;
            if(index != -1)
            {
                Vector3 wp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                                Input.mousePosition.y, 
                                                                cam.nearClipPlane));
                wp.x -= offset_x;
                wp.y -= offset_y;
                //l_obj[index].GetComponent<Rigidbody2D>().MovePosition(wp);
                l_obj[index].transform.position = wp;
            }
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
                    state = States.BEGAN;
                    for(int i=0; i<l_obj.Count; i++)
                    {
                        float w = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.x;
                        float h = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.y;
                        float x = l_obj[i].transform.position.x - w / 2f;
                        float y = l_obj[i].transform.position.y - h / 2f;
                        Rect rect = new Rect(x,y,w,h);
                        if (rect.Contains(touch.position))
                        {
                            debug_print("Yes! " + i);
                            debug_print(touch.position.x + ":" + touch.position.y);
                            offset_x = touch.position.x - l_obj[i].transform.position.x;
                            offset_y = touch.position.y - l_obj[i].transform.position.y;
                            debug_print("offset: " + offset_x + ":" + offset_y);
                            index = i;
                        }
                    }
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    state = States.MOVED;
                    if(index != -1)
                    {
                        Vector2 vp = touch.position;
                        vp.x -= offset_x;
                        vp.y -= offset_y;
                        //l_obj[index].GetComponent<Rigidbody2D>().MovePosition(vp);
                        l_obj[index].transform.position = vp;
                    }
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    state = States.ENDED;
                    break;
            }
        }
#endif    
    }
}
