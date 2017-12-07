using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	bool flag_left = false;
	bool flag_right = false;
	bool flag_up = false;
	bool flag_down = false;

	float X = 0;
	float Y = 0;
	float Z = 0;

	float delta = 0.1f;

	// Use this for initialization
	void Start () {
		X = transform.position.x;
		Y = transform.position.y;
		Z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		float tX = Input.GetAxis("Horizontal");
		float tY = Input.GetAxis("Vertical");
		if (tX > 0)	X -= delta;
		if (tX < 0) X += delta;
		if (tY > 0) Y -= delta;
		if (tY < 0) Y += delta;

		transform.position = new Vector3(X, Y, Z);
	}
}
