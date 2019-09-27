using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject sphere;
    public float force_x = 1f;
    public float force_y = 1f;
    public float force_z = 1f;
    public float force = 10f;

    public float k_move = 0.1f;
    public float k_rot = 0.5f;

    private Rigidbody body_sphere;
    private Vector3 m_NewForce;
    private Vector3 begin_pos;

    private List<GameObject> l_cubes;
    private List<Vector3> l_vectors;

    Camera m_MainCamera;

    void Start()
    {
        body_sphere = sphere.GetComponent<Rigidbody>();
        begin_pos = body_sphere.transform.position;

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

    void Update()
    {
        // движение
        m_MainCamera.transform.Translate (0, 0, Input.GetAxis("Vertical")*k_move);

        // поворот
        m_MainCamera.transform.Rotate(0, Input.GetAxis("Horizontal")*k_rot, 0, Space.Self);

        if (Input.GetButtonDown("Fire1"))
        {
            print("Fire");
            
            m_NewForce.x = force_x * force;
            m_NewForce.y = force_y * force;
            m_NewForce.z = force_z * force;

            body_sphere.AddForce(m_NewForce, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Jump"))
        {
            print("Jump");

            body_sphere.isKinematic = true;
            body_sphere.transform.position = begin_pos;
            body_sphere.isKinematic = false;

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
