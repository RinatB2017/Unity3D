using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public GameObject cannonball;
    public Text info_angle;
    public Text info_power;
    public float angle = 30f;   //56
    public float power = 100f;  //13

    void Awake()
    {
        transform.Rotate(Vector3.forward * angle);

        info_angle.text = angle.ToString();
        info_power.text = power.ToString();
    }

    void Inc_angle()
    {
        angle += 1f;
        transform.Rotate(Vector3.forward);  // временно
        info_angle.text = angle.ToString();
    }

    void Dec_angle()
    {
        angle -= 1f;
        transform.Rotate(Vector3.forward * -1);  // временно
        info_angle.text = angle.ToString();
    }

    void Inc_power()
    {
        power += 1f;
        info_power.text = power.ToString();
    }

    void Dec_power()
    {
        power -= 1f;
        info_power.text = power.ToString();
    }

    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
      
    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }

    void Shoot()
    {
        print("Shoot");

        Vector3 m_NewForce;

        Vector2 vector = DegreeToVector2(angle);
        m_NewForce.x = vector.x * power;
        m_NewForce.y = vector.y * power;
        m_NewForce.z = 0;

        Vector3 temp_vector = transform.position;

        GameObject ball;
        ball = Instantiate(cannonball, temp_vector, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().AddForce(m_NewForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        
    }
}
