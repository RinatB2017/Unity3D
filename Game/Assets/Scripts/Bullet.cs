using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; }  get { return parent; } }

    private float speed = 10.0F;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    public Color Color
    {
        set { sprite.color = value; }
    }

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Destroy(gameObject, 1.4F);
    }
	

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

	private void FixedUpdate()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1F);
		if (colliders.Length > 1)
		{
			//Debug.Log("Bullet Destroy");
			Destroy(gameObject);
		}
	}
    
	private void OnTriggerEnter2D(Collider2D collider)
    {
		/*
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit.gameObject != parent)
        {
            Destroy(gameObject);
        }
        */
	}
}
