using UnityEngine;
using UnityEngine.UI;

public class Click : DebugClass
{
    public GameObject gameObject;
    public string f_name;

    void OnMouseDown()
    {
        gameObject.SendMessage(f_name);
    }
}
