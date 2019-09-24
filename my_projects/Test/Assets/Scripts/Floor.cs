using System.Collections;
using System.Collections.Generic;
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
        info.text = "UP";
        print("up");
    }

    void down()
    {
        info.text = "DOWN";
        print("down");
    }

    void left()
    {
        print("left");
    }

    void right()
    {
        print("right");
    }

    void Update()
    {
        
    }
}
