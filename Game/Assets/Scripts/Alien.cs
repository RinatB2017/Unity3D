using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

	protected virtual void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("Alien: OnTriggerEnter2D");
		Bullet bullet = collider.GetComponent<Bullet>();
		if (bullet)
		{
			Debug.Log("Destroy(gameObject)");
			Destroy(gameObject);
		}
	}

	void Start () {
		
	}
	
	void Update () {
		
	}
}
