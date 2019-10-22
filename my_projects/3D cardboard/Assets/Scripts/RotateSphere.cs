﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour {
    public GameObject p_sphere;
    float angle = 0f;
    public float inc_angle = 0.1f;
    public float radius = 3f;

    public static Vector2 RadianToVector2 (float radian) {
        return new Vector2 (Mathf.Cos (radian), Mathf.Sin (radian));
    }

    public static Vector2 DegreeToVector2 (float degree) {
        return RadianToVector2 (degree * Mathf.Deg2Rad);
    }

    void Start () {
        angle = 0f;
    }

    void Update () {
        float x = Mathf.Cos (angle * Mathf.Deg2Rad) * radius;
        float y = 0f;
        float z = Mathf.Sin (angle * Mathf.Deg2Rad) * radius;

        Vector3 new_pos;
        new_pos.x = x;
        new_pos.y = y;
        new_pos.z = z;

        p_sphere.transform.position = new_pos;

        angle += inc_angle;
        if (angle >= 360f) {
            angle = 0f;
        }
    }
}