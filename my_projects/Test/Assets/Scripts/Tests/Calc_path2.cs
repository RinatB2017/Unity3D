using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calc_path2 : MonoBehaviour
{
    public PathCreator path_creator;
    public GameObject ball_prefab;

    List<Vector2> path_poins;
    int index = 0;
    public float speed = 10.0f;

    private Vector2 target;

    void Awake()
    {
        path_poins = new List<Vector2>();

        // print("NumSegments " + path_creator.path.NumSegments);
        for(int n=0; n<path_creator.path.NumSegments; n++)
        {
            Vector2[] points = path_creator.path.GetPointsInSegment(n);
            // print("N " + n + " count " + points.Length);
            for(int i=0; i<points.Length; i++)
            {
                path_poins.Add(points[i]);
            }
        }      
        print("Count2 " + path_poins.Count);

        index = 0;
        target = path_poins[index];
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        ball_prefab.transform.position = Vector2.MoveTowards(ball_prefab.transform.position, target, step);

        Vector2 pos = ball_prefab.transform.position;
        for(int n=0; n<path_poins.Count; n++)
        {
            if(pos == path_poins[n])
            {
                index++;
                if(index >= path_poins.Count)
                {
                    index = 0;
                }

                target = path_poins[index];
                return;
            }
        }
    }
}
