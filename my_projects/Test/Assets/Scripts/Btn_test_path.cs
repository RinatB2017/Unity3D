using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_test_path : MonoBehaviour
{
    public PathCreator path_creator;

    [ContextMenu("Do Something")]
    void DoSomething()
    {
        Debug.Log("Perform operation");
    }
    
    void OnMouseDown()
    {
        print("Click");
        print("NumSegments " + path_creator.path.NumSegments);
        
        var segment = path_creator.path.GetPointsInSegment(0);
        print(segment);
        print(segment[0].x);
        print(segment[0].y);
    }
}
