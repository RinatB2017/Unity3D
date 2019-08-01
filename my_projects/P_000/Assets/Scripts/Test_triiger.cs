using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_triiger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("OnTriggerExit");
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("OnTriggerStay");
    }
}
