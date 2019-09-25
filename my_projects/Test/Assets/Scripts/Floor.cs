// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Floor : MonoBehaviour
{
    public TextMeshPro info;
    private float height = 0f;

    void Start()
    {
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    float get_height()
    {
        return height;
    }

    void up()
    {
        set_text("UP");
    }

    void down()
    {
        set_text("DOWN");
    }

    void left()
    {
        set_text("LEFT");
    }

    void right()
    {
        set_text("RIGHT");
    }

    void set_text(string text)
    {
        info.text = text;
        print(text);
    }

    void Update()
    {
        
    }
}
