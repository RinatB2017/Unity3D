using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball_prefab;
    private Rigidbody2D ball;
    private Vector3 m_force;

    void Awake()
    {
        ball = ball_prefab.GetComponent<Rigidbody2D>();
    }

    void jump_left(bool state)
    {
        if(state)
        {
            print("Left");

            m_force.x = ball.transform.position.x - 1f;
            m_force.y = ball.transform.position.x;
            m_force.z = 0;

            ball.AddForce(m_force, ForceMode2D.Impulse);
        }
    }

    void jump_right(bool state)
    {
        if(state)
        {
            print("Right");

            m_force.x = ball.transform.position.x + 1f;
            m_force.y = ball.transform.position.x;
            m_force.z = 0;

            ball.AddForce(m_force, ForceMode2D.Impulse);
        }
    }
}
