using UnityEngine;
using System.Collections;

public class DeleteGameObject : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -8f) {
            Destroy(gameObject);
        }
    }
}
