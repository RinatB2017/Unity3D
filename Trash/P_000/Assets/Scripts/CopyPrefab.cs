// Instantiates 10 copies of Prefab each 2 units apart from each other

using UnityEngine;
using System.Collections;

public class CopyPrefab : MonoBehaviour
{
    public Transform prefab;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(prefab, new Vector3(-6 + i * 1.3F, 0, 0), Quaternion.identity);
        }
    }
}
