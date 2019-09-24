// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Floor : MonoBehaviour
{
    public TextMeshPro info;

    void Start()
    {

    }

    void up()
    {
        set_text("UP");
        print("up");
    }

    void down()
    {
        set_text("DOWN");
        print("down");
    }

    void left()
    {
        set_text("LEFT");
        print("left");
    }

    void right()
    {
        set_text("RIGHT");
        print("right");
    }

    void set_text(string text)
    {
        info.text = text;
    }

    void Update()
    {
        
    }
}
