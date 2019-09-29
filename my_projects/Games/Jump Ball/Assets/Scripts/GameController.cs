using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball_prefab;
    public float k_x = 10f;
    public float k_y = 10f;

    private Rigidbody2D ball;
    private Vector3 m_force;

    void Awake()
    {
        ball = ball_prefab.GetComponent<Rigidbody2D>();
    }

    void exit()
    {
        print("exit");
    }

    void jump_left(bool state)
    {
        if(state)
        {
            // print("Left");

            m_force.x = -k_x;
            m_force.y = k_y;
            m_force.z = 0;

            ball.AddForce(m_force, ForceMode2D.Impulse);
        }
    }

    void jump_right(bool state)
    {
        if(state)
        {
            // print("Right");

            m_force.x = k_x;
            m_force.y = k_y;
            m_force.z = 0;

            ball.AddForce(m_force, ForceMode2D.Impulse);
        }
    }
}
