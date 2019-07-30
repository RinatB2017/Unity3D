using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	bool flag = false;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "ground")
		{
			flag = true;
		}
		if (col.gameObject.tag == "bag")
		{
			// game over
			SceneManager.LoadScene("scene2");
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (flag && Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
			flag = false;
		}	
	}
}
