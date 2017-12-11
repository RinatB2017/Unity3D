using UnityEngine;
using System.Collections;

public class ShootableMonster : Monster
{
    [SerializeField]
    private float rate = 2.0F;
    [SerializeField]
    private Color bulletColor = Color.white;

    private Bullet bullet;
	private Bullet bullet2;

	protected override void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
		bullet2 = Resources.Load<Bullet>("Bullet");
	}

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot()
    {
        Vector3 position = transform.position;
		position.x -= 0.8F;
		position.y += 0.7F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = -newBullet.transform.right;
        newBullet.Color = bulletColor;

		//---
		Vector3 position2 = transform.position;
		position2.x += 0.8F;
		position2.y += 0.7F;
		Bullet newBullet2 = Instantiate(bullet2, position2, bullet2.transform.rotation) as Bullet;

		newBullet2.Parent = gameObject;
		newBullet2.Direction = newBullet2.transform.right;
		newBullet2.Color = bulletColor;
	}

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)
        {
			if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F)
			{
				ReceiveDamage();
			}
			else
			{
				unit.ReceiveDamage();
			}
        }
    }
}
