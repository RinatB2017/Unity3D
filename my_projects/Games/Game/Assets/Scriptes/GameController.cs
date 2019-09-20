using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject leftBoundary;
    public GameObject rightBoundary;
    public GameObject topBoundary;
    public GameObject bottomBoundary;

    public List<GameObject> l_obj;
    private float timer = 0f;

    public GameObject   player;
    public GameObject[] respawns;

    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
        l_obj = new List<GameObject>();

        debug_print("Awake");
        // if (respawns == null)
        {
            respawns = GameObject.FindGameObjectsWithTag("Enemy");
        }
        debug_print("Length " + respawns.Length);
    }

    private void debug_print(string text)
    {
        print(text);
    }

    void kill(GameObject obj)
    {
    	//print("KILL");
        //Destroy(obj);
        GameObject nearest = null;

        for (var i = 0; i < l_obj.Count; i++) 
        {
            if(l_obj[i] == obj)
            {
            	print("KILL");
                nearest = l_obj[i];
                l_obj.Remove(nearest);
                Destroy(nearest);
            }
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 0.1f)
        {
            timer = 0f;
            for(var n=0; n<l_obj.Count; n++)
            {
                Vector2 position = l_obj[n].transform.position;
                position.y -= 0.1f;
                l_obj[n].GetComponent<Rigidbody2D>().MovePosition(position);
            }
        }
    }
}
