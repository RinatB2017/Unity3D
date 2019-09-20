using UnityEngine;
using System.Collections;

public class CreateNewObj : MonoBehaviour
{
    //public Transform prefab;

    void OnMouseDown()
    {
        Debug.Log("down");

        GameObject player2;
        player2 = new GameObject("Player666");
        player2.AddComponent<SpriteRenderer>();
        player2.AddComponent<Rigidbody2D>();
        player2.AddComponent<BoxCollider2D>();

        Vector3 temp = new Vector3(0, 0, 0);
        Instantiate(player2, temp, Quaternion.identity);
    }

    void OnMouseUp()
    {
        Debug.Log("up");
    }
}
