using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
 
public class Keyboard : MonoBehaviour
{
    private int cnt = -1;

    private Vector2 old_position;
    private Vector2 new_position;

    public Rigidbody2D rigidbody2D;
    public float speed = 0.1f;
    private bool f_left  = false;
    private bool f_right = false;
    private bool f_up    = false;
    private bool f_down  = false;

    private int s_width = 0;
    private int s_height = 0;

    // public Text info_1;
    // public Text info_2;
    // public Text info_3;
    // public Text info_4;

    public Image btn_left;
    public Image btn_right;
    public Image btn_up;
    public Image btn_down;

    public List<Image> lists;
    public List<Rect>  rects;

    public Rect rect_left;
    public Rect rect_right;
    public Rect rect_up;
    public Rect rect_down;

    void debug_print(string text)
    {
        //print(text);
    }

    void Awake()
    {
        s_width  = Screen.width;
        s_height = Screen.height;
        debug_print("width  " + s_width);
        debug_print("height " + s_height);

        for(int i=0; i<lists.Count; i++)
        {
            Rect rect = rects[i]; 
            rect.x = lists[i].rectTransform.localPosition.x;
            rect.y = lists[i].rectTransform.localPosition.y;
            rect.width = lists[i].rectTransform.rect.width;
            rect.height = lists[i].rectTransform.rect.height;
            // нельзя напрямую копировать из списка в список - нужен промежуточный объект
            rects[i] = rect;
        }

        old_position = new Vector2(0, 0);
        new_position = new Vector2(0, 0);

        rect_left.x = btn_left.rectTransform.localPosition.x;
        rect_left.y = btn_left.rectTransform.localPosition.y;
        rect_left.width = btn_left.rectTransform.rect.width;
        rect_left.height = btn_left.rectTransform.rect.height;

        rect_right.x = btn_right.rectTransform.localPosition.x;
        rect_right.y = btn_right.rectTransform.localPosition.y;
        rect_right.width = btn_right.rectTransform.rect.width;
        rect_right.height = btn_right.rectTransform.rect.height;
        
        rect_up.x = btn_up.rectTransform.localPosition.x;
        rect_up.y = btn_up.rectTransform.localPosition.y;
        rect_up.width = btn_up.rectTransform.rect.width;
        rect_up.height = btn_up.rectTransform.rect.height;
        
        rect_down.x = btn_down.rectTransform.localPosition.x;
        rect_down.y = btn_down.rectTransform.localPosition.y;
        rect_down.width = btn_down.rectTransform.rect.width;
        rect_down.height = btn_down.rectTransform.rect.height;
    }

    bool check_btn_left(float x, float y)
    {
        float x1 = rect_left.x;
        float y1 = rect_left.y;
        float x2 = x1 + rect_left.width;
        float y2 = y1 - rect_left.height;

        if(x < x1)  return false;
        if(x > x2)  return false;
        if(y > y1)  return false;
        if(y < y2)  return false;

        debug_print("click left");
        return true;
    }
    
    bool check_btn_right(float x, float y)
    {
        float x1 = rect_right.x;
        float y1 = rect_right.y;
        float x2 = x1 + rect_right.width;
        float y2 = y1 - rect_right.height;

        if(x < x1)  return false;
        if(x > x2)  return false;
        if(y > y1)  return false;
        if(y < y2)  return false;

        debug_print("click right");
        return true;
    }

    bool check_btn_up(float x, float y)
    {
        float x1 = rect_up.x;
        float y1 = rect_up.y;
        float x2 = x1 + rect_up.width;
        float y2 = y1 - rect_up.height;

        if(x < x1)  return false;
        if(x > x2)  return false;
        if(y > y1)  return false;
        if(y < y2)  return false;

        debug_print("click up");
        return true;
    }

    bool check_btn_down(float x, float y)
    {
        float x1 = rect_down.x;
        float y1 = rect_down.y;
        float x2 = x1 + rect_down.width;
        float y2 = y1 - rect_down.height;

        if(x < x1)  return false;
        if(x > x2)  return false;
        if(y > y1)  return false;
        if(y < y2)  return false;

        debug_print("click down");
        return true;
    }

    bool is_pressed_left()
    {
        cnt = Input.touchCount;
        if(cnt == 0)
        {
            return false;
        }
        Touch[] myTouch = Input.touches;
        float x = 0f;
        float y = 0f;
        for (int i = 0; i < cnt; ++i)
        {
            x = myTouch[i].position.x - s_width / 2f;
            y = myTouch[i].position.y - s_height / 2f;

            if(check_btn_left(x, y)) return true;
        }        
        return false;
    }

    bool is_pressed_right()
    {
        cnt = Input.touchCount;
        if(cnt == 0)
        {
            return false;
        }
        Touch[] myTouch = Input.touches;
        float x = 0f;
        float y = 0f;
        for (int i = 0; i < cnt; ++i)
        {
            x = myTouch[i].position.x - s_width / 2f;
            y = myTouch[i].position.y - s_height / 2f;

            if(check_btn_right(x, y)) return true;
        }        
        return false;
    }

    bool is_pressed_up()
    {
        cnt = Input.touchCount;
        if(cnt == 0)
        {
            return false;
        }
        Touch[] myTouch = Input.touches;
        float x = 0f;
        float y = 0f;
        for (int i = 0; i < cnt; ++i)
        {
            x = myTouch[i].position.x - s_width / 2f;
            y = myTouch[i].position.y - s_height / 2f;

            if(check_btn_up(x, y)) return true;
        }        
        return false;
    }

    bool is_pressed_down()
    {
        cnt = Input.touchCount;
        if(cnt == 0)
        {
            return false;
        }
        Touch[] myTouch = Input.touches;
        float x = 0f;
        float y = 0f;
        for (int i = 0; i < cnt; ++i)
        {
            x = myTouch[i].position.x - s_width / 2f;
            y = myTouch[i].position.y - s_height / 2f;

            if(check_btn_down(x, y)) return true;
        }        
        return false;
    }

    //float x = Input.GetTouch (i).position.x - 1280f / 2f;
    //float y = Input.GetTouch (i).position.y - 720f / 2f;
    private void check_touch()
    {
        f_left  = is_pressed_left();
        f_right = is_pressed_right();
        f_up    = is_pressed_up();
        f_down  = is_pressed_down();

        // info_1.text = f_left  ? "Down" : "Up";
        // info_2.text = f_right ? "Down" : "Up";
        // info_3.text = f_up    ? "Down" : "Up";
        // info_4.text = f_down  ? "Down" : "Up";

        if(f_left)  new_position.x = new_position.x - speed;
        if(f_right) new_position.x = new_position.x + speed;
        if(f_up)    new_position.y = new_position.y + speed;
        if(f_down)  new_position.y = new_position.y - speed;
    }

    void check_keyboard()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(horizontal < 0) new_position.x = new_position.x - speed;
        if(horizontal > 0) new_position.x = new_position.x + speed;
        if(vertical < 0)   new_position.y = new_position.y - speed;
        if(vertical > 0)   new_position.y = new_position.y + speed;
    }

    void Update ()
    {
        //check_touch();
        //check_keyboard();
    }
}
