using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour {
	public GameObject circle;

	void AddGameObject()
	{
		circle.tag = "bag";
		Instantiate(circle);
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating("AddGameObject", 1f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
