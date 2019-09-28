using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject sphere_prefab;
    public float axes_x = 0f;
    public float axes_y = 1f;
    public float axes_z = 1f;
    public float force = 10f;

    public float k_move = 0.1f;
    public float k_rot = 0.5f;

    private GameObject sphere;
    private Rigidbody body_sphere;
    private Vector3 m_NewForce;

    public float runSpeed = 1f;
    public Joystick rotate_joystick;
    public Joystick move_joystick;

    private List<GameObject> l_cubes;
    private List<Vector3> l_vectors;

    private bool f_forward = false;
    private bool f_back = false;

    Camera m_MainCamera;

    void Start()
    {
        m_MainCamera = Camera.main;

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        print("Cubes " + cubes.Length);

        l_cubes = new List<GameObject>();
        l_vectors = new List<Vector3>();
        for(int n=0; n<cubes.Length; n++)
        {
            l_vectors.Add(cubes[n].transform.position);
            l_cubes.Add(cubes[n]);
        }
    }

    void move_forward(bool state)
    {
        f_forward = state;
    }

    void move_back(bool state)
    {
        f_back = state;
    }

    void fire(bool state)
    {
        if(state)
        {
            print("Fire");
            
            m_NewForce = m_MainCamera.transform.forward * force;

            Vector3 temp_vector = m_MainCamera.transform.position;

            sphere = Instantiate(sphere_prefab, temp_vector, Quaternion.identity);
            body_sphere = sphere.GetComponent<Rigidbody>();
            body_sphere.AddForce(m_NewForce, ForceMode.Impulse);
        }
    }

    void Update()
    {
        // движение
        // m_MainCamera.transform.Translate (0,
        //                                   0,
        //                                   Input.GetAxis("Vertical")*k_move);
        
        m_MainCamera.transform.Translate (move_joystick.Horizontal*k_move, 
                                          move_joystick.Vertical*k_move,
                                          0);

        // поворот
        // m_MainCamera.transform.Rotate(0,
        //                               Input.GetAxis("Horizontal")*k_rot,
        //                               0,
        //                               Space.Self);

        m_MainCamera.transform.Rotate(rotate_joystick.Vertical*k_rot,
                                      rotate_joystick.Horizontal*k_rot, 
                                      0,
                                      Space.Self);

        if(f_forward)
        {
            m_MainCamera.transform.Translate (0, 0, k_move);
        }
        if(f_back)
        {
            m_MainCamera.transform.Translate (0, 0, -k_move);
        }

        if (Input.GetButtonDown("Jump"))
        {
            print("Jump");

            Quaternion target = Quaternion.Euler(0, 0, 0);
            for(int n=0; n<l_cubes.Count; n++)
            {
                // target = Quaternion.Euler(l_vectors[n]);
                // print(target);
                l_cubes[n].GetComponent<Rigidbody>().isKinematic = true;
                l_cubes[n].transform.position = l_vectors[n];
                l_cubes[n].transform.rotation = Quaternion.Slerp(l_cubes[n].transform.rotation, 
                                                                 target,
                                                                 1);
                l_cubes[n].GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
