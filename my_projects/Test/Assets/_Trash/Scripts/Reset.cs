using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject main;

    void OnMouseDown()
    {
        main.SendMessage("reset");
    }
}
