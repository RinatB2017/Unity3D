using UnityEngine;

// Transform.Rotate example
//
// Two cubes are created.  One (red) is rendered using Space.Self.  The
// other (green) uses Space.World.  The rotation is controlled using xAngle,
// yAngle and zAngle. Over time, the cubes rotate differently.

public class ExampleScript : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    public Material selfMat, worldMat;

    private GameObject cube1, cube2;

    void Awake()
    {
        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = new Vector3(0.75f, 0.0f, 0.0f);
        cube1.GetComponent<Renderer>().material = selfMat;
        cube1.name = "Self";

        cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = new Vector3(-0.75f, 0.0f, 0.0f);
        cube2.GetComponent<Renderer>().material = worldMat;
        cube2.name = "World";
    }

    void Update()
    {
        cube1.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        cube2.transform.Rotate(xAngle, yAngle, zAngle, Space.World);
    }
}
