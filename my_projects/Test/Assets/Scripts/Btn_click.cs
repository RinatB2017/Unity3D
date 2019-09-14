using UnityEngine;
using System.Collections;

public class Btn_click : DebugClass
{
    public GameObject gameObject;
    public string f_name;
    
    void OnMouseDown()
    {
        gameObject.SendMessage(f_name, true);
    }

    void OnMouseUp()
    {
        gameObject.SendMessage(f_name, false);
    }
}
