using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform prefab;

    public float radius = 5.0F;
    public float power = 50.0F;
    public float upwardModifier = -3.0f;

    private float start_x = -2f;
    private float start_y = 0.5f;
    private float start_z = -2f;

    private static int cnt_x = 4;
    private static int cnt_y = 12;
    private static int cnt_z = 4;

    private Rigidbody[] cubes = new Rigidbody[(cnt_x + 1) * (cnt_y + 1) * (cnt_z + 1)];

    void Start()
    {
        int index = 0;
        for(float z=start_z; z<=(start_z + cnt_z); z+=1.0f)
        {
            for(float y=start_y; y<=(start_y + cnt_y); y+=1.0f)
            {
                for(float x=start_x; x<=(start_x + cnt_x); x+=1.0f)
                {
                    Vector3 temp_vector = new Vector3(x, y, z);
                    // Rigidbody cube = Instantiate(prefab, temp_vector, Quaternion.identity) as Rigidbody;
                    // cubes[index++] = cube;
                    Transform cube = Instantiate(prefab, temp_vector, Quaternion.identity);
                    cubes[index++] = cube.GetComponent<Rigidbody>();
                }
            }
        }
        // Vector3 temp_vector = new Vector3(1, 0.5f, 1);
        // Instantiate(prefab, temp_vector, Quaternion.identity);
    }

    void self_explosion()
    {
        print("BOOM");
        for(int i = 0; i < cubes.Length; i++)
        {
            cubes[i].AddExplosionForce(power, 
                                       cubes[i].position,
                                       radius,
                                       upwardModifier,
                                       ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            self_explosion();
        }
    }
}
