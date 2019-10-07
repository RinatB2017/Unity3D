using UnityEngine;
using System.Collections;
 
public class PlayerController : DebugClass 
{
    // Using same speed reference in both, desktop and other devices
    public float speed = 1000;
    public Rigidbody2D rigidbody;
 
    void Main ()
    {
        // Preventing mobile devices going in to sleep mode 
        //(actual problem if only accelerometer input is used)
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
 
    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop) 
        {
            // Exit condition for Desktop devices
            if (Input.GetKey("escape"))
                Application.Quit();
        }
        else
        {
            // Exit condition for mobile devices
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();            
        }
    }
     
    void FixedUpdate ()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop) 
        { 
            // Player movement in desktop devices
            // Definition of force vector X and Y components
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            // Building of force vector
            //Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
            Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0f);
            // Adding force to rigidbody
            rigidbody.AddForce(movement * speed * Time.deltaTime);
        }
        else
        {
            // Player movement in mobile devices
            // Building of force vector 
            //Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
            Vector3 movement = new Vector3 (Input.acceleration.x, Input.acceleration.y, 0f);
            // Adding force to rigidbody
            rigidbody.AddForce(movement * speed * Time.deltaTime);
        }
    }
}
