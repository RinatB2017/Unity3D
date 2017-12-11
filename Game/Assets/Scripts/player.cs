using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	[SerializeField]
	private Color bulletColor = Color.white;

	bool flag_left = false;
	bool flag_right = false;
	bool flag_up = false;
	bool flag_down = false;

	float X = 0;
	float Y = 0;
	float Z = 0;

	float delta = 0.1f;

	private Bullet bullet;
	private SpriteRenderer sprite;

	private void Shoot(bool is_right)
	{
		Vector3 position = transform.position;
		if(is_right)
			position.x -= 0.8F;
		else
			position.x += 0.8F;
		Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

		newBullet.Parent = gameObject;
		newBullet.Direction = is_right ? -newBullet.transform.right : newBullet.transform.right;
		newBullet.Color = bulletColor;
	}

	void OnGUI()
	{
		int h = 20;
		GUI.Label(new Rect(0, 0, 100, h), "X=" + X);
		GUI.Label(new Rect(0, h, 100, h), "Y=" + Y);
		GUI.Label(new Rect(0, h * 2, 100, h), "Z=" + Z);
	}

	// Use this for initialization
	void Start () {
		X = transform.position.x;
		Y = transform.position.y;
		Z = transform.position.z;

		bullet = Resources.Load<Bullet>("Bullet");
		sprite = GetComponentInChildren<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		float tX = Input.GetAxis("Horizontal");
		float tY = Input.GetAxis("Vertical");
		sprite.flipX = tX < 0;
		if (tX > 0)	X += delta;
		if (tX < 0) X -= delta;
		if (tY > 0) Y += delta;
		if (tY < 0) Y -= delta;

		transform.position = new Vector3(X, Y, Z);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Shoot(tX < 0);
		}
	}
}
