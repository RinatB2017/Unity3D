using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchPhaseExample : MonoBehaviour
{
    void Update()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    print("Began");
                    print(touch.position.x + ":" + touch.position.y);
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    print("Moved");
                    print(touch.position.x + ":" + touch.position.y);
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    print("Ended");
                    print(touch.position.x + ":" + touch.position.y);
                    break;
            }
        }
    }
}
