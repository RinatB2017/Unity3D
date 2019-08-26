using UnityEngine;

public class GetImpulse : MonoBehaviour
{
    private Vector3 m_NewForce;
    private Rigidbody2D Rigid;

    void Awake() 
    {
        m_NewForce.x = 0;
        m_NewForce.y = 20;
        m_NewForce.z = 0;
    }

    void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Ball") 
		{
            Rigid = other.GetComponent<Rigidbody2D>();

            Rigid.AddForce(m_NewForce, ForceMode2D.Impulse);
        }
	}
}
