using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : DebugClass
{
    public GameObject obj;
    public List<GameObject> buttons;
    public List<string> f_list;

    private int index = -1;
    private float offset_x = 0f;
    private float offset_y = 0f;

    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    private void analize(Vector3 vp, int i)
    {
        float w = 1f; //buttons[i].GetComponent<Image>().sprite.rect.width;
        float h = 1f; //buttons[i].GetComponent<Image>().sprite.rect.height;
        float x = buttons[i].transform.position.x - w / 2f;
        float y = buttons[i].transform.position.y - h / 2f;
        Rect rect = new Rect(x,y,w,h);
        if (rect.Contains(vp))
        {
            offset_x = vp.x - buttons[i].transform.position.x;
            offset_y = vp.y - buttons[i].transform.position.y;
            // debug_print("Yes! " + i);
            // debug_print("Vp " + vp.x + ":" + vp.y);
            // debug_print("Coord " + x + ":" + y + " " + w + ":" + h);
            // debug_print(vp.x + ":" + vp.y);
            // debug_print("offset: " + offset_x + ":" + offset_y);
            index = i;
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButton(0))
        {
            Vector3 vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                            Input.mousePosition.y, 
                                                            cam.nearClipPlane));
            for(int i=0; i<buttons.Count; i++)
            {
                analize(vp, i);
                if(index != -1)
                {
                    // debug_print("INDEX: " + index);
                    obj.SendMessage(f_list[index]);
                }
            }
        }
        // else if (Input.GetMouseButtonUp(0))
        // {
        //     index = -1;
        // }
        // else if (Input.GetMouseButton(0))
        // {
        //     if(index != -1)
        //     {
        //         Vector3 vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
        //                                                         Input.mousePosition.y, 
        //                                                         cam.nearClipPlane));
        //         vp.x -= offset_x;
        //         vp.y -= offset_y;
        //         obj.SendMessage(f_list[index]);
        //         // buttons[index].GetComponent<Rigidbody2D>().MovePosition(vp);
        //         // buttons[index].transform.position = vp;
        //     }
        // }
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
                    for(int i=0; i<buttons.Count; i++)
                    {
                        analize(vp, i);
                        if(index != -1)
                        {
                            obj.SendMessage(f_list[index]);
                        }
                    }
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                // case TouchPhase.Moved:
                //     if(index != -1)
                //     {
                //         vp = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));
                //         vp.x -= offset_x;
                //         vp.y -= offset_y;
                //         obj.SendMessage(f_list[index]);
                //         // buttons[index].GetComponent<Rigidbody2D>().MovePosition(vp);
                //         // buttons[index].transform.position = vp;
                //     }
                //     break;

                // Report that a direction has been chosen when the finger is lifted.
                // case TouchPhase.Ended:
                //     index = -1;
                //     break;
            }
        }
#endif            
    }
}
