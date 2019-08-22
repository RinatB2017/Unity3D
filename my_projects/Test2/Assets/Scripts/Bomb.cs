using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Boundary" && other.gameObject.name != "Top Boundary") 
		{
			print("KILL");
			Destroy(gameObject);
		}
	}
}
