using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball_prefab;

    void jump_left(bool state)
    {
        if(state)
        {
            print("Left");
        }
    }

    void jump_right(bool state)
    {
        if(state)
        {
            print("Right");
        }
    }
}
