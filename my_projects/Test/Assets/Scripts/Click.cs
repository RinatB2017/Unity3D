using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour
{
    public string s_name;

    void OnMouseDown()
    {
        Debug.Log("down " + s_name);
    }

    void OnMouseUp()
    {
        Debug.Log("up " + s_name);
    }
}
