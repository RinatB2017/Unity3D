using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour
{
    public GameObject floor;
    
    void Start()
    {
        // test();
        // test2();
    }

    void test()
    {
        var obj = FindObjectOfType<Floor>();
        if(obj)
        {
            print("YES");
            Vector2 pos;
            pos.x = 0;
            pos.y = 0;
            obj.transform.position = pos;
        }
        else
        {
            print("NO");
        }
    }

    void test2()
    {
        // var foundObjects = FindObjectsOfType<Bomb>();
        // print(foundObjects + " : " + foundObjects.Length);

        // var className = Resources.Load<Bomb>("Assets");
        // print(className);

        // var enemy = Resources.Load("Prefabs/Enemy", typeof(GameObject));
        // var enemy = Resources.Load<Enemy>("Enemy");
        // print(enemy);

        // GameObject instance = Instantiate(Resources.Load("Enemy", typeof(GameObject))) as GameObject;
    }

    void Update()
    {
        
    }
}
