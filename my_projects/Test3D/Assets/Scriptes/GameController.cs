using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject sphere;
    public float force_x = 0f;
    public float force_y = 10f;
    public float force_z = 0f;

    private Rigidbody body_sphere;
    private Vector3 m_NewForce;
    private Vector3 begin_pos;

    void Start()
    {
        body_sphere = sphere.GetComponent<Rigidbody>();
        begin_pos = body_sphere.transform.position;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            print("Fire");
            
            m_NewForce.x = force_x;
            m_NewForce.y = force_y;
            m_NewForce.z = force_z;

            body_sphere.AddForce(m_NewForce, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Jump"))
        {
            print("Jump");

            body_sphere.isKinematic = true;
            body_sphere.transform.position = begin_pos;
            body_sphere.isKinematic = false;
        }
    }
}
