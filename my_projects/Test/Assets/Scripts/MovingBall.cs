using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour {
    public float speed = 1f;
    public float radius = 0.51f;
    int direction = 1;

    void Start () {

    }

    void Update () {
        Vector2 pos = transform.position;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(pos, radius);
        // print("hit count " + hitColliders.Length);
        if(hitColliders.Length < 2) {
            direction *= -1;
            print("direction " + direction);
        }

        pos.x += direction * speed * Time.deltaTime;
        transform.position = pos;

        // float step = direction * speed * Time.deltaTime;
        // transform.position = Vector2.MoveTowards(transform.position, pos, step);
    }
}