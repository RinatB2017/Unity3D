using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDrawLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 begin = new Vector3(0f, 0f, 0f);
        Vector3 end = new Vector3(3f, 3f, 0f);
        Color color = new Color(1f, 0f, 0f, 0f);

        DrawLine(begin, end, color, 1f);
    }

    // https://answers.unity.com/questions/8338/how-to-draw-a-line-using-script.html
    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.name = "Line";
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        // lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}
