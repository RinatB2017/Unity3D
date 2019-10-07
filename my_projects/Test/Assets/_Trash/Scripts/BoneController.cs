using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoneController : DebugClass
{
    public List<GameObject> l_obj;

    private int index = -1;
    private float offset_x = 0f;
    private float offset_y = 0f;

    private Camera cam;

    private void create_world()
    {
        int x = -2;
        int y = -2;

        Vector2 temp_vector = new Vector2(0, 0);
        for(var n=0; n<l_obj.Count; n++)
        {
            temp_vector.x = x;
            temp_vector.y = y;

            // l_obj[n].transform.position = temp_vector;
            l_obj[n].GetComponent<Rigidbody2D>().velocity = temp_vector;
            if(x < 2)
            {
                x++;
            }
            else
            {
                x=0;
                y++;
            }
        }
    }

    void Start()
    {
        cam = Camera.main;
        create_world();

        // l_obj = new List<GameObject>();
        // Vector2 temp_vector = new Vector2(0, 0);
        // for(var y=0; y<4; y++)
        // {
        //     for(var x=0; x<4; x++)
        //     {
        //         temp_vector.x = x;
        //         temp_vector.y = y;
        //         GameObject obj = Instantiate(bone, temp_vector, Quaternion.identity);
        //         // obj.SetActive(false);
        //         l_obj.Add(obj);
        //     }
        // }
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
        Vector3 vp;
        if(Input.GetMouseButtonDown(0))
        {
            vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            for(int i=0; i<l_obj.Count; i++)
            {
                analize(vp, i);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            index = -1;
        }
        else if (Input.GetMouseButton(0))
        {
            if(index != -1)
            {
                vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                        Input.mousePosition.y, 
                                                        cam.nearClipPlane));
                vp.x -= offset_x;
                vp.y -= offset_y;
                // l_obj[index].transform.position = vp;
                l_obj[index].GetComponent<Rigidbody2D>().velocity = vp;
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
                    for(int i=0; i<l_obj.Count; i++)
                    {
                        analize(vp, i);
                    }
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    if(index != -1)
                    {
                        vp = cam.ScreenToWorldPoint(new Vector3(touch.position.x,
                                                                touch.position.y, 
                                                                cam.nearClipPlane));
                        vp.x -= offset_x;
                        vp.y -= offset_y;
                        // l_obj[index].transform.position = vp;
                        l_obj[index].GetComponent<Rigidbody2D>().velocity = vp;
                    }
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    index = -1;
                    break;
            }
        }
#endif    
    }
}
