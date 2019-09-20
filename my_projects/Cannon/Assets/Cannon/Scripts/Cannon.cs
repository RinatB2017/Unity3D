using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public GameObject cannonball;
    public Text info_angle;
    public Text info_power;
    public float angle = 30f;
    public float power = 100f;

    void Awake()
    {
        transform.Rotate(Vector3.forward * angle);

        info_angle.text = angle.ToString();
        info_power.text = power.ToString();
    }

    void Inc_angle()
    {
        angle += 1f;
        transform.Rotate(Vector3.forward);  // временно
        info_angle.text = angle.ToString();
    }

    void Dec_angle()
    {
        angle -= 1f;
        transform.Rotate(Vector3.forward * -1);  // временно
        info_angle.text = angle.ToString();
    }

    void Inc_power()
    {
        power += 1f;
        info_power.text = power.ToString();
    }

    void Dec_power()
    {
        power -= 1f;
        info_power.text = power.ToString();
    }

    void Shoot()
    {
        print("Shoot");
    }

    void Update()
    {
        
    }
}
