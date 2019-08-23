﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public Transform prefab;
    public float delay_sec = 1.5f;

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
            Vector3 temp_vector = new Vector3(Random.Range(-2.0f, 2.0f), 4f, 0);
            Instantiate(prefab, temp_vector, Quaternion.identity);
            yield return new WaitForSeconds(delay_sec);
        }
    }

    void Update()
    {
        
    }
}
