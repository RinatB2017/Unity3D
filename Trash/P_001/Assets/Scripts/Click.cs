using UnityEngine;

public class Click : MonoBehaviour
{
    public Transform prefab;
    
    private void find_obj()
    {
        Tux tux = (Tux)FindObjectOfType(typeof(Tux));
        if(tux)
        {
            print("value = " + tux.get_value());
            print("name  = " + tux.get_name());
        }
    }

    private void find_obj2()
    {
        var tux = FindObjectsOfType<Tux>();
        if(tux.Length != 0)
        {
            print("value = " + tux[0].get_value());
        }
    }

    void OnMouseDown()
    {
        Debug.Log("down");
        //Instantiate(prefab, new Vector3(1, 1, 0), Quaternion.identity);

        find_obj();
    }

    void OnMouseUp()
    {
        Debug.Log("up");
    }
}
