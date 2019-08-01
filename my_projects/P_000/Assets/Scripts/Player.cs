using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10.0f;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;
    
    //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
    }

    //If your GameObject keeps colliding with another GameObject with a Collider, do something
    void OnCollisionStay2D(Collision2D collision)
    {
        //Check to see if the Collider's name is "Test_1"
        if (collision.collider.name == "Test_1")
        {
            //Output the message
            Debug.Log("Test_1 is here!");
        }
    }

    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;

        cam = Camera.main;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    void OnGUI()
    {
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        Vector2 point = new Vector2();

        // compute where the mouse is in world space
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));

        if (Input.GetMouseButtonDown(0))
        {
            // set the target to the mouse click location
            target = point;
        }
    }
}
