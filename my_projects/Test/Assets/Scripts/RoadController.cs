using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : DebugClass
{
    public List<GameObject> prefabs;
    public Vector2 position;
    public float step = 0.1f;

    private List<GameObject> l_obj;
    private float h_obj = 1.0f;

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 pos = col.transform.position;
        pos.y += prefabs.Count * h_obj;

        col.transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Vector2 pos = col.transform.position;
        pos.y += prefabs.Count * h_obj;

        col.transform.position = pos;
    }

    void Start()
    {
        l_obj = new List<GameObject>();

        h_obj = prefabs[0].GetComponent<SpriteRenderer>().bounds.size.y;

        for(int n=0; n<prefabs.Count; n++)
        {
            GameObject obj = Instantiate(prefabs[n], position, Quaternion.identity);
            l_obj.Add(obj);

            position.y += h_obj;
        }
    }

    void move()
    {
        Vector2 temp_pos;
        for(int n=0; n<l_obj.Count; n++)
        {
            temp_pos = l_obj[n].transform.position;
            temp_pos.y -= step;

            l_obj[n].GetComponent<Rigidbody2D>().MovePosition(temp_pos);
        }
    }

    void Update()
    {
        move();
    }
}
