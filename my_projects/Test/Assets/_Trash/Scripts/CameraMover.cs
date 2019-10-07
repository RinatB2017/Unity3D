using UnityEngine;

public class CameraMover : MonoBehaviour
{
    Camera m_MainCamera;
    float k = 0.1f;

    void Start()
    {
        m_MainCamera = Camera.main;
    }

    void Update()
    {
        m_MainCamera.transform.Translate (Input.GetAxis("Horizontal")*k,
                                          Input.GetAxis("Vertical")*k,
                                          0);
    }
}
