using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPhaseExample : DebugClass
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

    private void analize(Vector3 vp, int i)
    {
        float w = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.x;
        float h = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.y;
        float x = l_obj[i].transform.position.x - w / 2f;
        float y = l_obj[i].transform.position.y - h / 2f;
        Rect rect = new Rect(x,y,w,h);
        if (rect.Contains(vp))
        {
            debug_print("Yes! " + i);
            debug_print(vp.x + ":" + vp.y);
            offset_x = vp.x - l_obj[i].transform.position.x;
            offset_y = vp.y - l_obj[i].transform.position.y;
            debug_print("offset: " + offset_x + ":" + offset_y);
            index = i;
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            state = States.BEGAN;
            Vector3 vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

            for(int i=0; i<l_obj.Count; i++)
            {
                analize(vp, i);
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
                Vector3 vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                                Input.mousePosition.y, 
                                                                cam.nearClipPlane));
                vp.x -= offset_x;
                vp.y -= offset_y;
                //l_obj[index].GetComponent<Rigidbody2D>().MovePosition(vp);
                l_obj[index].transform.position = vp;
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
                    state = States.BEGAN;
                    vp = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));
                    for(int i=0; i<l_obj.Count; i++)
                    {
                        analize(vp, i);
                    }
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    state = States.MOVED;
                    if(index != -1)
                    {
                        vp = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));
                        vp.x -= offset_x;
                        vp.y -= offset_y;
                        //l_obj[index].GetComponent<Rigidbody2D>().MovePosition(vp);
                        l_obj[index].transform.position = vp;
                    }
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    state = States.ENDED;
                    index = -1;
                    break;
            }
        }
#endif    
    }
}
