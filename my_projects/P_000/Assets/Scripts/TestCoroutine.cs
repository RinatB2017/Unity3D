using UnityEngine;
using System.Collections;

public class TestCoroutine : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector2 target;
    
    void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        while(true) {
            transform.Translate(0.1f, 0, Time.deltaTime);
            yield return new WaitForSeconds(0.1f);
            print("OK");
        }
    }
}
