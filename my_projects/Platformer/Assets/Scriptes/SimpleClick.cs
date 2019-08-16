using UnityEngine;
using System.Collections;

public class SimpleClick : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("down");
    }

    void OnMouseUp()
    {
        Debug.Log("up");
    }
}
