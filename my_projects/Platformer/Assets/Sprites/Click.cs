using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour
{
    public Transform prefab;
    public float new_y;

    private IEnumerator coroutine;
    
    void Awake()
    {
        new_y = transform.position.y + transform.localScale.y;
    }
    
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
                                          new_y,
                                          transform.position.z);
        Instantiate(prefab, temp_vector, Quaternion.identity);
        
        new_y = transform.position.y + transform.localScale.y;
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
