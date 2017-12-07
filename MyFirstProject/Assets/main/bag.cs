using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag : MonoBehaviour {
	Vector2 vel = new Vector2(-12, 0);

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = vel;
		transform.position = new Vector3(
			transform.position.x,
			transform.position.y,
			transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody2D>().position.x < -10)
		{
			// вышли за пределы поля 
			//TODO надо бы убрать магическую константу -10
			Destroy(GetComponent<Rigidbody2D>().gameObject);
		}
	}
}
