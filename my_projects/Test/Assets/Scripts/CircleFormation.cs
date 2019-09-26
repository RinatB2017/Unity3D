using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFormation : MonoBehaviour
{
    // Instantiates prefabs in a circle formation
    public GameObject prefab;
    public GameObject platform;
    public int numberOfObjects = 8;
    public float radius = 3f;
    public float force = 1f;

    private List<GameObject> l_prefab;
    private List<GameObject> l_platform;

    void Start()
    {
        init();
    }

    void init()
    {
        init_prefabs();
        init_platforms();

        print("Prefab name " + prefab.name);
        print("Count " + l_prefab.Count);
    }

    void init_prefabs()
    {
        l_prefab = new List<GameObject>();
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            Vector2 pos = transform.position + new Vector3(x, y, 0);
            pos.y += 1f;
            float angleDegrees = -angle*Mathf.Rad2Deg;

            GameObject child = Instantiate(prefab, pos, Quaternion.identity);
            
            child.transform.SetParent(gameObject.transform);
            l_prefab.Add(child);
        }
    }

    void init_platforms()
    {
        l_platform = new List<GameObject>();
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            Vector2 pos_platform = transform.position + new Vector3(x, y, 0);
            GameObject child = Instantiate(platform, pos_platform, Quaternion.identity);

            child.transform.SetParent(gameObject.transform);
            l_platform.Add(child);
        }
    }

    void reset()
    {
        print("Reset");

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            Vector2 pos = new Vector3(x, y, 0);
            pos.y += 1f;

            l_prefab[i].GetComponent<Rigidbody2D>().isKinematic = true;
            l_prefab[i].GetComponent<Rigidbody2D>().rotation = 0f;
            l_prefab[i].transform.position = pos;
            l_prefab[i].GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    void OnMouseDown()
    {
        // print("Click");
        for(int n=0; n<l_prefab.Count; n++)
        {
            Vector2 p1 = Vector2.zero;
            Vector2 p2 = l_prefab[n].transform.position;

            float angle = Mathf.Atan2(p2.y-p1.y, p2.x-p1.x) * Mathf.Rad2Deg;
            // print("angle " + angle);

            Vector3 m_NewForce;
            m_NewForce.x = l_prefab[n].transform.position.x * force;
            m_NewForce.y = l_prefab[n].transform.position.y * force;
            m_NewForce.z = 0;

            l_prefab[n].GetComponent<Rigidbody2D>().AddForce(m_NewForce, ForceMode2D.Impulse);
        }
    }
}
