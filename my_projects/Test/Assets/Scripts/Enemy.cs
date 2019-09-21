using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemy;
    private Vector3 m_NewForce;

    void Start()
    {
        Vector3 temp_vector = new Vector3(0, 0, 0);

        enemy = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_NewForce.x = Random.Range(-2.0f, 2.0f);
        m_NewForce.y = Random.Range(-2.0f, 2.0f);
        m_NewForce.z = 0;

        enemy.AddForce(m_NewForce, ForceMode2D.Impulse);
    }
}
