using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    public float angleDegrees = 0f;
    public float radius = 25f;

    void Start()
    {
        cam = Camera.main;
    }

    public void move_left()
    {
        angleDegrees -= 1f;
        if(angleDegrees < 0f)    angleDegrees += 360f;

        float x = Mathf.Cos(angleDegrees) * radius;
        float z = Mathf.Sin(angleDegrees) * radius;

        // Vector3 pos = transform.position + new Vector3(x, 0, z);
        // Vector3 pos = new Vector3(x, 0, z);
        // cam.transform.localPosition = pos;

        Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
        cam.transform.localRotation = rot;
        print("move left");
    }

    public void move_right()
    {
        angleDegrees += 1f;
        if(angleDegrees >= 360f)    angleDegrees -= 360f;

        Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
        cam.transform.localRotation = rot;
        print("move right");
    }

    void Update()
    {
        
    }
}
