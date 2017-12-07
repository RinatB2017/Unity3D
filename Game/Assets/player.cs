using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (transform.position.x < Screen.width)
			{
				transform.position = new Vector2(transform.position.x + 0.1f,
				                                 transform.position.y);
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (transform.position.x > 0)
			{
				transform.position = new Vector2(transform.position.x - 0.1f,
												 transform.position.y);
			}
		}
	}
}
