using UnityEngine;
using System.Collections;

// Applies an explosion force to all nearby rigidbodies
public class ExplosionClass : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    void self_explosion()
    {
        print("BOOM");
        Vector3 explosionPos = transform.position;
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(power, 
                                                               explosionPos,
                                                               radius,
                                                               3.0F,
                                                               ForceMode.Impulse);
        // gameObject.GetComponent<Rigidbody>().AddExplosionForce(force,
        //                                                        transform.position,
        //                                                        radius,
        //                                                        force*0.5f,
        //                                                        ForceMode.Impulse);
    }

    void test()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            else
                print("rb is NULL");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //self_explosion();
        }
    }
}
