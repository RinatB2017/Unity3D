using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCapsule : MonoBehaviour {
    public GameObject p_capsule;
    GameObject capsule;
    Vector3 pos;

    public float min_dist = -11f;
    public float max_dist = 100f;
    float dist = 99f;
    public float inc_dict = 0.5f;
    int dir = 1;

    void Start () {
        pos = new Vector3 (0f, 2.5f, 100f);
        capsule = Instantiate (p_capsule, pos, Quaternion.identity);
        capsule.transform.Rotate (90, 0, 0, Space.Self);
    }

    void Update () {
        pos.z = dist;
        capsule.transform.position = pos;

        dist += (dir * inc_dict);
        if ((dist <= min_dist) || (dist >= max_dist)) {
            dir *= -1;
        }
    }
}