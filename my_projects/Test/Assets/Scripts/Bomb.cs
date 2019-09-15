using UnityEngine;

public class Bomb : DebugClass
{
    void OnTriggerExit2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Boundary" && other.gameObject.name != "Top Boundary") 
		{
			debug_print("KILL");
			Destroy(gameObject);
		}
	}
}
