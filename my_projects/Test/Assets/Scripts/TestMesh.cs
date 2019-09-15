using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMesh : DebugClass
{
    void Start()
    {
        GetComponent<TextMesh>().text = "Hello World";
    }
}
