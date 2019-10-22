// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour {
    public GameObject p_sphere;
    GameObject sphere;
    float angle = 0f;
    public float inc_angle = 0.1f;
    public float radius = 3f;

    void Start () {
        angle = 0f;

        Vector3 pos = new Vector3(0f, 0f, 0f);
        sphere = Instantiate(p_sphere, pos, Quaternion.identity);
    }

    void Update () {
        Vector3 new_pos;
        new_pos.x = Mathf.Cos (angle * Mathf.Deg2Rad) * radius;
        new_pos.y = 1f;
        new_pos.z = Mathf.Sin (angle * Mathf.Deg2Rad) * radius;

        sphere.transform.position = new_pos;

        angle += inc_angle;
        if (angle >= 360f) {
            angle = 0f;
        }
    }
}