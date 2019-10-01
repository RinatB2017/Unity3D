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

    private float begin_time = 0f;
    private float end_time = 0f;
    private float elapsed_time = 0f;

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
            begin_time = Time.time;
        }
        else
        {
            end_time = Time.time;
            elapsed_time = end_time - begin_time;

            m_force.x = -(elapsed_time / k_x);
            if(m_force.x < -k_x) m_force.x = -k_x;
            m_force.y = k_y;
            m_force.z = 0;

            /*
            k_x 100
            e   x
             */
            print("jump_left");
            print("k_x " + k_x);
            print("elapsed_time " + elapsed_time);
            print("m_force.x " + m_force.x);

            ball.AddForce(m_force, ForceMode2D.Impulse);
        }
    }

    void jump_right(bool state)
    {
        if(state)
        {
            begin_time = Time.time;
        }
        else
        {
            end_time = Time.time;
            elapsed_time = end_time - begin_time;

            m_force.x = (elapsed_time / k_x);
            if(m_force.x > k_x) m_force.x = k_x;
            m_force.y = k_y;
            m_force.z = 0;

            print("jump_right");
            print("k_x " + k_x);
            print("elapsed_time " + elapsed_time);
            print("m_force.x " + m_force.x);

            ball.AddForce(m_force, ForceMode2D.Impulse);
        }
    }
}
