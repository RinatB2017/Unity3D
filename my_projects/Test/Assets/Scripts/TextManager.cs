// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    void Start()
    {
        EventManager.StartListening ("MyEvent", MyFunction);
    }

    void MyFunction (string param)
    {
        GetComponent<Text>().text = param;
    }
}
