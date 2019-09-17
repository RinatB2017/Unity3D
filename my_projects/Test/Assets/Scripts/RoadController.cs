using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : DebugClass
{
    public List<GameObject> prefabs;
    public Vector2 position;
    public float step = 0.1f;

    private List<GameObject> l_obj;
    private float h_road = 0f;

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 pos = col.transform.position;
        pos.y += h_road;

        col.transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Vector2 pos = col.transform.position;
        pos.y += h_road;

        col.transform.position = pos;
    }

    void Start()
    {
        l_obj = new List<GameObject>();

        for(int n=0; n<prefabs.Count; n++)
        {
            GameObject obj = Instantiate(prefabs[n], position, Quaternion.identity);
            h_road += prefabs[n].GetComponent<SpriteRenderer>().bounds.size.y;
            position.y += prefabs[n].GetComponent<SpriteRenderer>().bounds.size.y;
            l_obj.Add(obj);
        }
    }

    void move()
    {
        Vector2 temp_pos;
        for(int n=0; n<l_obj.Count; n++)
        {
            temp_pos = l_obj[n].transform.position;
            temp_pos.y -= step;

            l_obj[n].transform.position = temp_pos;
        }
    }

    void Update()
    {
        move();
    }
}
