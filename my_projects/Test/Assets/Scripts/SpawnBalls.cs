using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    public Rigidbody2D prefab;
    public float delay_sec = 1.5f;

    private Vector3 m_NewForce;

    private IEnumerator coroutine;

    void Start()
    {
        coroutine = DropBombes();
        StartCoroutine(coroutine);
    }

	private IEnumerator DropBombes () 
	{
        while (true)
        {
            Vector3 temp_vector = new Vector3(0, 0, 0);

            m_NewForce.x = Random.Range(-20.0f, 20.0f);
            m_NewForce.y = Random.Range(-20.0f, 20.0f);
            m_NewForce.z = 0;

            Rigidbody2D clone;
            clone = Instantiate(prefab, temp_vector, Quaternion.identity);
            clone.AddForce(m_NewForce, ForceMode2D.Impulse);

            yield return new WaitForSeconds(delay_sec);
        }
    }

    void Update()
    {
        
    }
}
