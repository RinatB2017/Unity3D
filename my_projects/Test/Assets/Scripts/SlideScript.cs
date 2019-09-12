using UnityEngine;

public class SlideScript : MonoBehaviour
{
    public float speed = 200f;

    public float min_h = -10f;
    public float max_h = 10f;

    private enum States 
	{ 
		NONE, BEGAN, ENDED, MOVED
	};
    private States state = States.NONE;
    private Vector2 position;
    private float offset_x = 0f;
    private float offset_y = 0f;

    private bool f_moved = false;

    public GameObject sprite_R;
    public GameObject sprite_G;
    public GameObject sprite_B;

    private GameObject g_R;
    private GameObject g_G;
    private GameObject g_B;

    private float h_R;
    private float h_G;
    private float h_B;

    private Camera cam;

    void debug_print(string text)
    {
        print(text);
    }

    void Awake()
    {
        cam = Camera.main;

        h_R = sprite_R.GetComponent<SpriteRenderer>().bounds.size.y;
        h_G = sprite_G.GetComponent<SpriteRenderer>().bounds.size.y;
        h_B = sprite_B.GetComponent<SpriteRenderer>().bounds.size.y;
        debug_print("h_R " + h_R);
        debug_print("h_G " + h_G);
        debug_print("h_B " + h_B);

        Vector2 begin_position = new Vector2(0, 0);
        position = new Vector2(0, 0);

        g_R = Instantiate(sprite_R, begin_position, Quaternion.identity);
        g_G = Instantiate(sprite_G, begin_position, Quaternion.identity);
        g_B = Instantiate(sprite_B, begin_position, Quaternion.identity);
    }

    void move(Vector2 position)
    {
        g_R.GetComponent<Rigidbody2D>().MovePosition(position);
        position.y += h_R;
        g_G.GetComponent<Rigidbody2D>().MovePosition(position);
        position.y += h_G;
        g_B.GetComponent<Rigidbody2D>().MovePosition(position);
    }

    void sliding()
    {
#if UNITY_EDITOR
        Vector3 vp;
        if(Input.GetMouseButtonDown(0))
        {
            state = States.BEGAN;
            f_moved = true;
            vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                    Input.mousePosition.y, 
                                                    cam.nearClipPlane));
            offset_y = vp.y - position.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            state = States.ENDED;
            f_moved = false;
        }
        else if (Input.GetMouseButton(0))
        {
            state = States.MOVED;
            if(f_moved)
            {
                vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                        Input.mousePosition.y, 
                                                        cam.nearClipPlane));
                vp.x = 0;
                vp.y -= offset_y;
                position = vp;
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
                    state = States.BEGAN;
                    f_moved = true;
                    vp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                            Input.mousePosition.y, 
                                                            cam.nearClipPlane));
                    offset_y = vp.y - position.y;                    
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    state = States.MOVED;
                    if(f_moved)
                    {
                        vp = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));
                        vp.x = 0;
                        vp.y -= offset_y;
                        position = vp;
                    }
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    state = States.ENDED;
                    f_moved = false;
                    break;
            }
        }
#endif    
    }

    void Update()
    {
        sliding();
        move(position);
    }
}
