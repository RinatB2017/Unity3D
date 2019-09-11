using UnityEngine;

public class MoveScript : MonoBehaviour
{
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

    private float begin_h = 0f;
    Vector2 begin_position;

    private float timer = 0f;

    void debug_print(string text)
    {
        print(text);
    }

    void Awake()
    {
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

            begin_h += inc_h;
            if(begin_h <= min_h)
            {
                inc_h *= -1f;
            }
            if(begin_h >= max_h)
            {
                inc_h *= -1f;
            }

            begin_position.y = begin_h;
            move(begin_position);
        }
    }
}
