using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Click : DebugClass
{
    public string   s_name;
    public Text     s_text;

    void OnMouseDown()
    {
        debug_print("down " + s_name);
        s_text.text = s_name +" down";
    }

    void OnMouseUp()
    {
        debug_print("up " + s_name);
        s_text.text = s_name +" up";
    }
}
