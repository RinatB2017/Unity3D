using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Top Boundary"    ||
            other.gameObject.tag == "Bottom Boundary" || 
            other.gameObject.tag == "Left Boundary"   || 
            other.gameObject.tag == "Right Boundary") 
		{
			print("KILL");
			Destroy(gameObject);
		}
	}
}
