using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_list : MonoBehaviour
{
    public List<GameObject> go_list;

    void Start()
    {
        for(var n=0; n<10; n++)
        {
            go_list.Add(new GameObject());
        }
    }

    void Update()
    {
        
    }
}
