using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
 
public class Keyboard : MonoBehaviour
{
    private int cnt = -1;

    private bool f_left  = false;
    private bool f_right = false;
    private bool f_up    = false;
    private bool f_down  = false;

    private int s_width = 0;
    private int s_height = 0;

    public List<Image>  buttons;
    public List<string> f_names;
    public List<Text>   t_info;
    public List<Rect>   rects;

    public GameObject   player;

    void debug_print(string text)
    {
        print(text);
    }

    void Awake()
    {
        s_width  = Screen.width;
        s_height = Screen.height;
        debug_print("width  " + s_width);
        debug_print("height " + s_height);

        for(int i=0; i<buttons.Count; i++)
        {
            Rect rect = rects[i]; 
            rect.x = buttons[i].rectTransform.localPosition.x;
            rect.y = buttons[i].rectTransform.localPosition.y;
            rect.width = buttons[i].rectTransform.rect.width;
            rect.height = buttons[i].rectTransform.rect.height;
            // нельзя напрямую копировать из списка в список - нужен промежуточный объект
            rects[i] = rect;
        }
    }

    bool check_btn(Rect rect, float x, float y)
    {
        float x1 = rect.x;
        float y1 = rect.y;
        float x2 = x1 + rect.width;
        float y2 = y1 - rect.height;

        if(x < x1)  return false;
        if(x > x2)  return false;
        if(y > y1)  return false;
        if(y < y2)  return false;

        return true;
    }

    bool is_pressed(Rect rect)
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

            if(check_btn(rect, x, y)) return true;
        }        
        return false;
    }

    private void check_touch2()
    {
        f_left  = is_pressed(rects[0]);
        f_right = is_pressed(rects[1]);
        f_up    = is_pressed(rects[2]);
        f_down  = is_pressed(rects[3]);

        if(f_left)  player.SendMessage(f_names[0]);
        if(f_right) player.SendMessage(f_names[1]);
        if(f_up)    player.SendMessage(f_names[2]);
        if(f_down)  player.SendMessage(f_names[3]);

        t_info[0].text = f_left  ? "Down" : "Up";
        t_info[1].text = f_right ? "Down" : "Up";
        t_info[2].text = f_up    ? "Down" : "Up";
        t_info[3].text = f_down  ? "Down" : "Up";
    }

    private void check_touch()
    {
        for(int n=0; n<4; n++)
        {
            bool flag = is_pressed(rects[n]);
            if(flag) player.SendMessage(f_names[n]);
            t_info[n].text = flag ? "Down" : "Up";
        }
    }

    private void check_keys()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical   = Input.GetAxis("Vertical");
        if(horizontal < 0)  player.SendMessage(f_names[0]);
        if(horizontal > 0)  player.SendMessage(f_names[1]);
        if(vertical > 0)    player.SendMessage(f_names[2]);
        if(vertical < 0)    player.SendMessage(f_names[3]);
    }

    void Update ()
    {
        check_touch();
        check_keys();
    }
}
