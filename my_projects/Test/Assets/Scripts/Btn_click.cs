using UnityEngine;
using System.Collections;

public class Btn_click : DebugClass
{
    public GameObject gameObject;
    public string f_name;

    void Awake()
    {
        print("btn_click: awake");
    }
    
    void OnMouseDown()
    {
        debug_print("DOWN: " + f_name);
        gameObject.SendMessage(f_name, true);
    }

    void OnMouseUp()
    {
        debug_print("UP: " + f_name);
        gameObject.SendMessage(f_name, false);
    }
}
