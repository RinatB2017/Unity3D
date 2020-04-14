using UnityEngine;
using System.Collections;

public class Btn_click : MonoBehaviour
{
    public GameObject game_controller;
    public string f_name;
   
    void OnMouseDown()
    {
        game_controller.SendMessage(f_name, true);
    }

    void OnMouseUp()
    {
        game_controller.SendMessage(f_name, false);
    }
}
