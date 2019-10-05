using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_test_path : MonoBehaviour
{
    public PathCreator path_creator;
    public GameObject  ball_prefab;
    Rigidbody2D ball_rb2D;

    public float speed = 10.0f;
    private Vector2 target;

    List<Vector2> l_pos;
    int index = 0;

    // [ContextMenu("Do Something")]
    // void DoSomething()
    // {
    //     Debug.Log("Perform operation");
    // }

    void Start()
    {
        ball_rb2D = ball_prefab.GetComponent<Rigidbody2D>();
        l_pos = new List<Vector2>();
        l_pos.Add(new Vector2(0, 1));
        l_pos.Add(new Vector2(1, 1));
        l_pos.Add(new Vector2(1, 0));
        l_pos.Add(new Vector2(0, 0));

        index = 0;
        target = l_pos[index];
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        ball_prefab.transform.position = Vector2.MoveTowards(ball_prefab.transform.position, target, step);

        // Vector2 pos = ball_prefab.transform.position;
        // for(int n=0; n<l_pos.Count; n)
        // {
        //     if(pos == l_pos[n])
        //     {
        //         // ball_prefab.transform.position = l_pos[index];
        //         ball_rb2D.velocity = l_pos[index];
        //         return;
        //     }
        // }
    }
    
    void OnMouseDown()
    {
        // path_creator.path.AddSegment(new Vector2(5, 5));

        print("Click");
        // print("NumSegments " + path_creator.path.NumSegments);
        
        // var segment = path_creator.path.GetPointsInSegment(0);
        // print(segment);
        // print(segment[0].x);
        // print(segment[0].y);

        // Vector2 vec = new Vector2(1, 1);
        // ball_rb2D.velocity = vec;

        // ball_prefab.transform.position = l_pos[index];
        index++;
        if(index >= l_pos.Count)
            index = 0;

        //target = l_pos[index];
        target = new Vector2(5, 5);

        // ball_prefab.velocity = l_pos[index];
    }
}
