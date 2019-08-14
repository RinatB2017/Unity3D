using UnityEngine;
using System.Collections;

public class Btn_click : MonoBehaviour
{
    public Rigidbody2D player;
    public string f_name;
    
    void OnMouseDown()
    {
        player.gameObject.SendMessage(f_name, true);
    }

    void OnMouseUp()
    {
        player.gameObject.SendMessage(f_name, false);
    }
}
