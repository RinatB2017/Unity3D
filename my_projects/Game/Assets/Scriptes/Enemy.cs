using UnityEngine;

public class Enemy : MonoBehaviour
{
	public GameObject gameController;

    //void OnTriggerExit2D(Collider2D other) 
    void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.gameObject.tag == "Top Boundary"    ||
            other.gameObject.tag == "Bottom Boundary" || 
            other.gameObject.tag == "Left Boundary"   || 
            other.gameObject.tag == "Right Boundary") 
		{
			//Destroy(gameObject);
			gameController.SendMessage("kill", gameObject);
		}
	}
}
