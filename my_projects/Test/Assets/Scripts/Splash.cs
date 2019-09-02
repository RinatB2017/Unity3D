using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public float delay_sec = 2.5f;
    private IEnumerator coroutine;

    void Start()
    {
        coroutine = DropBombes();
        StartCoroutine(coroutine);        
    }

	private IEnumerator DropBombes () 
	{
        yield return new WaitForSeconds(delay_sec);
        Destroy(gameObject);
    }
}
