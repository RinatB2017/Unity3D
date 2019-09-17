using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public GameObject l_prefab;
    public GameObject r_prefab;

    public float delay_sec = 0.1f;

    public float x_Angle = -15f;
    public float z_Angle = 0f;

    public float l_Angle = 0f;
    public float r_Angle = 0.1f;
    public float step_angle = 0.1f;

    private IEnumerator coroutine;

    void Start()
    {
        l_prefab.transform.Rotate(x_Angle, l_Angle, z_Angle, Space.Self);
        r_prefab.transform.Rotate(x_Angle, r_Angle, z_Angle, Space.Self);

        coroutine = RotateCubes();
        StartCoroutine(coroutine);
    }

	private IEnumerator RotateCubes() 
	{
        while (true)
        {
            l_prefab.transform.Rotate(0, step_angle, 0, Space.Self);
            r_prefab.transform.Rotate(0, step_angle, 0, Space.Self);
            yield return new WaitForSeconds(delay_sec);
        }
    }
}
