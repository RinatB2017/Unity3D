using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PrefabController : MonoBehaviour
{
    public GameObject prefab;
    public int max_floor = 10;

    void Start()
    {
        // test();
        // test2();

        float h = prefab.GetComponent<TilemapRenderer>().bounds.size.y;
        print(h);

        // var tilemap = prefab.GetComponent<Tilemap>();
        // if(tilemap == null)
        // {
        //     print("tilemap not found");
        //     return;
        // }
        // float h = tilemap.GetComponent<TilemapRenderer>().bounds.size.y;
        // print(h);
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
