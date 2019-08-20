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

    public Text info_1;
    public Text info_2;
    public Text info_3;
    public Text info_4;

    public List<Image> lists;
    public List<Rect>  rects;

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

        debug_print("click left");
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

    private void check_touch()
    {
        f_left  = is_pressed(rects[0]);
        f_right = is_pressed(rects[1]);
        f_up    = is_pressed(rects[2]);
        f_down  = is_pressed(rects[3]);

        info_1.text = f_left  ? "Down" : "Up";
        info_2.text = f_right ? "Down" : "Up";
        info_3.text = f_up    ? "Down" : "Up";
        info_4.text = f_down  ? "Down" : "Up";
    }

    void Update ()
    {
        check_touch();
    }
}
