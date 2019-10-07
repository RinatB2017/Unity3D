// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Floor : MonoBehaviour
{
    public TextMeshPro info;
    private float height = 0f;

    public float get_height()
    {
        return height;
    }

    public void up()
    {
        set_text("UP");
    }

    public void down()
    {
        set_text("DOWN");
    }

    public void left()
    {
        set_text("LEFT");
    }

    public void right()
    {
        set_text("RIGHT");
    }

    public void set_text(string text)
    {
        info.text = text;
        print(text);
    }

    void Start()
    {
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        
    }
}
