using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    void OnGUI()
    {
        Event currentEvent = Event.current;
        GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");

        if (Input.GetMouseButtonDown(0))
        {
            float x = currentEvent.mousePosition.x;
            float y = currentEvent.mousePosition.y;
            Debug.Log(x + " : " + y);
        }
    }
    
    void OnMouseDrag()
    {
        print("Drag");
    }
    
    /*
    void Update () 
    {
        if(Input.GetAxis("Mouse X")<0)
        {
            print("Mouse moved left");
        }
        else if(Input.GetAxis("Mouse X")>0)
        {
            print("Mouse moved right");
        }
    }
    */
}
