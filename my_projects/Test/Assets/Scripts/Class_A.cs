using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class_A : Class_B
{
    public string name_A;

    void Start()
    {
        print("Name = " + my_name);        
        name_B = "XXX";
    }

    // void OnGUI()
    // {
    //     if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
    //     {
    //         print("You clicked the button!");
    //     }
    // }

    // public override void OnInspectorGUI()
    // {

    // }
}
