using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPhaseExample : MonoBehaviour
{
    public Rigidbody2D gameObject;
    public List<GameObject> l_obj;

    private bool f_moved = false;
    private int index = -1;

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

        for(int i=0; i<l_obj.Count; i++)
        {
            float x = l_obj[i].transform.position.x;
            float y = l_obj[i].transform.position.y;
            float width  = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.x;
            float height = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.y;
            print("Mace: " + x + ":" + y + " " + width + ":" + height);
        }

        // RectTransform rt = (RectTransform)mace.transform;
        // float width = rt.rect.width;
        // float height = rt.rect.height;
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
            //print("Began");
            //print(Input.mousePosition.x + ":" + Input.mousePosition.y);

            Vector3 wp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

            for(int i=0; i<l_obj.Count; i++)
            {
                float w = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.x;
                float h = l_obj[i].GetComponent<SpriteRenderer>().bounds.size.y;
                float x = l_obj[i].transform.position.x - w / 2f;
                float y = l_obj[i].transform.position.y - h /2f;
                Rect rect = new Rect(x,y,w,h);
                if (rect.Contains(wp))
                {
                    print("Yes! " + i);
                    print(wp.x + ":" + wp.y);
                    index = i;
                }
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            //print("Ended");
            //print(Input.mousePosition.x + ":" + Input.mousePosition.y);
            index = -1;
        }
        else if (Input.GetMouseButton(0))
        {
            //print("Moved");
            //print(Input.mousePosition.x + ":" + Input.mousePosition.y);

            if(index != -1)
            {
                Vector3 wp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
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
