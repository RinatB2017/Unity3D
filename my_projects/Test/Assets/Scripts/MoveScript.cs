using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    //public Rigidbody2D gameObject;
    public float speed = 200f;

    public float min_h = -10f;
    public float max_h = 10f;
    public float inc_h = 0.1f;

    public GameObject sprite_R;
    public GameObject sprite_G;
    public GameObject sprite_B;

    private GameObject g_R;
    private GameObject g_G;
    private GameObject g_B;

    private float h_R;
    private float h_G;
    private float h_B;

    private float begin_y = 0f;
    Vector2 begin_position;

    private float timer = 0f;

    private Camera cam;

    // private int s_width = 0;
    // private int s_height = 0;

    // public int PPU = 100;
    // float w_sprite = 1024;
    // float h_sprite = 768;

    void debug_print(string text)
    {
        print(text);
    }

    void Awake()
    {
        cam = Camera.main;

        // Vector3 screenPos = cam.WorldToScreenPoint(new Vector3(0, 0, 0));
        // debug_print("screenPos: " + screenPos);

        // s_width  = Screen.width;
        // s_height = Screen.height;
        // debug_print("width  " + s_width);
        // debug_print("height " + s_height);

        h_R = sprite_R.GetComponent<SpriteRenderer>().bounds.size.y;
        h_G = sprite_G.GetComponent<SpriteRenderer>().bounds.size.y;
        h_B = sprite_B.GetComponent<SpriteRenderer>().bounds.size.y;
        debug_print("h_R " + h_R);
        debug_print("h_G " + h_G);
        debug_print("h_B " + h_B);

        begin_position = new Vector2(0, 0);

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

    void Update()
    {
        timer += speed * Time.deltaTime;
        if(timer >= 0.1f)
        {
            timer = 0f;

            begin_y += inc_h;
            if(begin_y <= min_h)
            {
                inc_h *= -1f;
            }
            if(begin_y >= max_h)
            {
                inc_h *= -1f;
            }

            begin_position.y = begin_y;
            move(begin_position);
        }
    }
}
