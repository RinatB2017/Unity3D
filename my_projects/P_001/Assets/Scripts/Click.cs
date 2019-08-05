// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Transform prefab;
    
    void OnMouseDown()
    {
        Debug.Log("down");
        Instantiate(prefab, new Vector3(1, 1, 0), Quaternion.identity);
    }

    void OnMouseUp()
    {
        Debug.Log("up");
    }
}
