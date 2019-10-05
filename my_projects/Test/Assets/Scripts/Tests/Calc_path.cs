using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calc_path : MonoBehaviour
{
    public PathCreator path_creator;

    void OnMouseDown()
    {
        print("NumSegments " + path_creator.path.NumSegments);
    }
}
