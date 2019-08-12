using UnityEngine;
using System.Collections;

public class Btn_jump : MonoBehaviour
{
    public GameObject player;
    public float speed = 10f;

    void OnMouseDown()
    {
        Debug.Log("down");
    }
}
