using UnityEngine;

public class Test_click : MonoBehaviour
{
    [SerializeField]
    private float XXX = 1.0F;
    
    void OnMouseDown()
    {
        Debug.Log("down");
    }

    void OnMouseUp()
    {
        Debug.Log("up");
    }
}
