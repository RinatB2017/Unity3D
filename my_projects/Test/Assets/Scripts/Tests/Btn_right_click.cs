using UnityEngine;

public class Btn_right_click : MonoBehaviour
{
    public GameObject tilemap;
    bool flag = false;

    void OnMouseDown()
    {
        flag =  true;
    }

    void OnMouseUp()
    {
        flag = false;
    }

    void Update()
    {
        if(flag)
        {
            tilemap.transform.Rotate(0, 0, -1f, Space.Self);
        }
    }
}
