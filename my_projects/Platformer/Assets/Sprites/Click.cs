using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour
{
    public Transform prefab;

    private IEnumerator coroutine;
    
    void OnMouseDown()
    {
        Debug.Log("down");

        //add_obj();
        start_coroutine();
    }

    private void start_coroutine()
    {
        coroutine = WaitAndPrint(0.0001f);
        StartCoroutine(coroutine);
    }

    private void add_obj()
    {
        Vector3 temp_vector = new Vector3(transform.position.x, 
                                          transform.position.y + transform.localScale.y,
                                          transform.position.z);
        Instantiate(prefab, temp_vector, Quaternion.identity);
    }

    void OnMouseUp()
    {
        Debug.Log("up");
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            transform.Rotate(0, 0, 1);
        }
    }
}
