using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFormation : MonoBehaviour
{
    // Instantiates prefabs in a circle formation
    public GameObject prefab;
    public int numberOfObjects = 8;
    public float radius = 3f;
    public float force = 1f;

    private List<GameObject> l_obj;
    void Start()
    {
        print("Name " + prefab.name);
        
        l_obj = new List<GameObject>();
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            Vector2 pos = transform.position + new Vector3(x, y, 0);
            float angleDegrees = -angle*Mathf.Rad2Deg;

            Quaternion rot = Quaternion.Euler(0, 0, angleDegrees);
            
            GameObject child  = Instantiate(prefab, pos, rot);
            // GameObject child = Instantiate(prefab, pos, Quaternion.identity);
            
            child.transform.SetParent(gameObject.transform);
            l_obj.Add(child);

            float dist = Vector2.Distance(Vector2.zero, child.transform.position);
            print(child.name + " " + dist);
        }
        print("Count " + l_obj.Count);
    }

    void OnMouseDown()
    {
        // print("Click");
        for(int n=0; n<l_obj.Count; n++)
        {
            Vector2 p1 = Vector2.zero;
            Vector2 p2 = l_obj[n].transform.position;

            float angle = Mathf.Atan2(p2.y-p1.y, p2.x-p1.x) * Mathf.Rad2Deg;
            // print("angle " + angle);

            Vector3 m_NewForce;
            m_NewForce.x = l_obj[n].transform.position.x * force;
            m_NewForce.y = l_obj[n].transform.position.y * force;
            m_NewForce.z = 0;

            l_obj[n].GetComponent<Rigidbody2D>().AddForce(m_NewForce, ForceMode2D.Impulse);
        }
    }
}
