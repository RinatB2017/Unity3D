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

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		X = transform.position.x;
		Y = transform.position.y;
		Z = transform.position.z;
	}

	void OnGUI()
	{
		GUI.Label(new Rect(0, 0, 100, 100), "Z=" + Z);
	}
	
	// Update is called once per frame
	void Update () {
		float tX = Input.GetAxis("Horizontal");
		float tY = Input.GetAxis("Vertical");
		if (tX > 0)	X += delta;
		if (tX < 0) X -= delta;
		if (tY > 0) Y += delta;
		if (tY < 0) Y -= delta;

		transform.position = new Vector3(X, Y, Z);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
			//bullet.transform.position = new Vector3(10, 10, 0);

			//GameObject bullet = GameObject.Instantiate(bullet);
			//bullet.tag = "bullet";
			//Instantiate(Resources.Load("bullet"));
			//Instantiate(bullet);

			bullet = new GameObject("bullet");
			bullet.transform.position = new Vector3(X, Y, Z);
			bullet.transform.localScale = new Vector3(10, 10, 10);

			//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			//cube.AddComponent<Rigidbody>();
			//cube.transform.position = new Vector3(5, 5, 0);
		}
	}
}
