using UnityEngine;
using UnityEngine.UI;
 
/// <summary>
//	Allows "OnMouseDown()" events to work on touch devices.
/// </summary>
public class MouseDownTouch : MonoBehaviour
{
    private int cnt = -1;

    public Text pos_x;
    public Text pos_y;

    public Text pos_x1;
    public Text pos_y1;
    public Text pos_x2;
    public Text pos_y2;

    public Image btn_left;
    public Image btn_right;
    public Image btn_up;
    public Image btn_down;

    public Rect rect_left;
    public Rect rect_right;
    public Rect rect_up;
    public Rect rect_down;

    void Awake()
    {
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

        pos_x1.text = x1.ToString();
        pos_y1.text = y1.ToString();
        pos_x2.text = x2.ToString();
        pos_y2.text = y2.ToString();

        if(x < x1)  return false;
        if(x > x2)  return false;
        if(y < y1)  return false;
        if(y > y2)  return false;

        return true;
    }

    private void Update ()
    {
        cnt = Input.touchCount;
        if(cnt != 0)
        {
            for (int i = 0; i < cnt; ++i)
            {
                //float x = Input.GetTouch (i).position.x - 1280f / 2f;
                //float y = Input.GetTouch (i).position.y - 720f / 2f;
                float x = Input.GetTouch (i).position.x - Screen.width / 2f;
                float y = Input.GetTouch (i).position.y - Screen.height / 2f;
                pos_x.text = x.ToString();
                pos_y.text = y.ToString();

                if(check_btn_left(x, y))
                {
                    print("Btn_left click");
                }
            }
        }
    }
}
