using UnityEngine;
using System.Collections;

// Applies an explosion force to all nearby rigidbodies
public class ExampleClass : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    void self_explosion()
    {
        Vector3 explosionPos = transform.position;
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(power, 
                                                               explosionPos,
                                                               radius,
                                                               0.0F);
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

    void Start()
    {
        self_explosion();
    }
}
