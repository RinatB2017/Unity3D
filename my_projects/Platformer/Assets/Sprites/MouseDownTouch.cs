using UnityEngine;
using UnityEngine.UI;
 
/// <summary>
//	Allows "OnMouseDown()" events to work on touch devices.
/// </summary>
public class MouseDownTouch : MonoBehaviour
{
    private int old_cnt = -1;
    private int cnt = -1;

    public Text text;
    public Image image;

    private void Update ()
    {
        var hit = new RaycastHit ();
 
        cnt = Input.touchCount;
        if(cnt != old_cnt)
        {
            print(cnt);
            text.text = "Cnt: " + cnt.ToString ();
            old_cnt = cnt;
        }

        if(cnt != 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                //float x = Input.GetTouch (i).position.x - 1280f / 2f;
                //float y = Input.GetTouch (i).position.y - 720f / 2f;
                float x = Input.GetTouch (i).position.x - Screen.width / 2f;
                float y = Input.GetTouch (i).position.y - Screen.height / 2f;
                print("i: " + i.ToString());
                print("pos.x " + x);
                print("pos.y " + y);

                //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch (i).position); 
                //Vector3 pos = Camera.main.WorldToScreenPoint(Input.GetTouch (i).position); 
                //print("pos.x " + pos.x);
                //print("pos.y " + pos.y);

                // if (Input.GetTouch (i).phase.Equals (TouchPhase.Began))
                // {
                //     // Construct a ray from the current touch coordinates.
                //     Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (i).position);
    
                //     if (Physics.Raycast (ray, out hit))
                //     {
                //         hit.transform.gameObject.SendMessage ("OnMouseDown");
                //         print("pos.x " + hit.transform.position.x);
                //         print("pos.y " + hit.transform.position.y);
                //     }
                // }
            }
        }
    }
}
