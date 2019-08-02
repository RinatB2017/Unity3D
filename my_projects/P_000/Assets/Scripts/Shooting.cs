using UnityEngine; 
using System.Collections;

public class Shooting : MonoBehaviour 
{
    //public float bulletSpeed = 10;
    public float vector_x = 1;
    public float vector_y = 1;
    public Rigidbody2D bullet;
    Vector2 point;
    Vector2 mousePos;
    private Camera cam;
    
    void Fire(float x, float y)
    {
        Vector3 pos = new Vector3(x, y, 0);
        
        //Rigidbody2D bulletClone = (Rigidbody2D) Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D bulletClone = (Rigidbody2D) Instantiate(bullet, pos, transform.rotation);
        //bulletClone.velocity = transform.up * bulletSpeed;
        
        bulletClone.velocity = new Vector3(vector_x, vector_y, 0);
    }

    void Start()
    {
        cam = Camera.main;
        point = new Vector2();
        mousePos = new Vector2();
    }
    
    void OnGUI()
    {
        Event currentEvent = Event.current;

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire(point.x, point.y);
        }
    }
}
