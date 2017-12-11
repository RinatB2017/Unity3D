using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour {

	protected virtual void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("alien: OnTriggerEnter2D");
		Bullet bullet = collider.GetComponent<Bullet>();
		if (bullet)
		{
			Debug.Log("Destroy(gameObject)");
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
