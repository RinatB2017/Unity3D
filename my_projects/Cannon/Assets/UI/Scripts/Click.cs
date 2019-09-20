using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Click : DebugClass
{
    public GameObject gameObject;
    public string f_name;

    void OnMouseDown()
    {
        gameObject.SendMessage(f_name);
    }
}
