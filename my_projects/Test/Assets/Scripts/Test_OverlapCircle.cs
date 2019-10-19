using UnityEngine;

public class Test_OverlapCircle : MonoBehaviour
{
    void Start()
    {
        Vector2 center = new Vector2();
        center.x = 0f;
        center.y = 0f;
        float radius = 3f;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        print("hit count " + hitColliders.Length);
        for(int n=0; n<hitColliders.Length; n++) {
            Destroy(hitColliders[n].gameObject);
        }
    }
}
