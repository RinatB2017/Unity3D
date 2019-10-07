using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayer : MonoBehaviour
{
    public Joystick joystick;

    public Text text_x;
    public Text text_y;

    public float speed = 0.1f;

    void Start()
    {

    }

    void Update()
    {
        // keyboard
        transform.Translate (Input.GetAxis("Horizontal") * speed,
                             Input.GetAxis("Vertical")   * speed,
                             0);

        // joystick
        transform.Translate (joystick.Horizontal * speed,
                             joystick.Vertical   * speed,
                             0);

        float l_x = transform.localPosition.x;
        float l_y = transform.localPosition.y;
        text_x.text = l_x.ToString();
        text_y.text = l_y.ToString();
    }
}
