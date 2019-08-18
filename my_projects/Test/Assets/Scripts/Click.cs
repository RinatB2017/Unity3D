using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Click : MonoBehaviour
{
    public string   s_name;
    public Text     s_text;

    void OnMouseDown()
    {
        Debug.Log("down " + s_name);
        s_text.text = s_name +" down";
    }

    void OnMouseUp()
    {
        Debug.Log("up " + s_name);
        s_text.text = s_name +" up";
    }
}
