using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMath : MonoBehaviour
{
    private int x = 0;

    void Awake()
    {
        Vector2 v = DegreeToVector2(30f);
        print(v.x + " - " + v.y);

        Vector2 m_MyFirstVector;
        Vector2 m_MySecondVector;
        m_MyFirstVector  = new Vector2(1f, 0f);
        m_MySecondVector = new Vector2(1f, 1f);
        float m_Angle = Vector2.Angle(m_MyFirstVector, m_MySecondVector);
        print("angle " + m_Angle);
    }

    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
      
    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
}
