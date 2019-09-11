using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_scene : MonoBehaviour
{
    public GameObject prefab;
    private Vector2 begin_position = new Vector2(0, 0);
    private List<GameObject> l_obj;

    private float timer = 0f;

    void Start()
    {
        l_obj = new List<GameObject>(); 

        begin_position = new Vector2(0, 0);
        for(int n=0; n<10; n++)
        {
            begin_position.x = n - 5;
            GameObject obj = Instantiate(prefab, begin_position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().MovePosition(begin_position);
            obj.SetActive(false);
            l_obj.Add(obj);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1f)
        {
            timer = 0f;
            for(int n=0; n<l_obj.Count; n++)
            // for(int n=0; n<3; n++)
            {
                bool flag = l_obj[n].activeSelf;
                l_obj[n].SetActive(!flag);
            }
        }
    }
}
