
using UnityEngine;

public class FirstExerciseSphereObserver : MonoBehaviour
{
    public string cylinderTag = "Cylinder";
    public string type1Tag = "Type1";
    public string type2Tag = "Type2";
    public Transform greenSphere;
    public float force = 10f;
    public float stoppingDistance = 3f;

    private Rigidbody rb;
    private FirstExerciseCylinderNotifier cylinder;
    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject cylinderObject = GameObject.FindWithTag(cylinderTag);
        cylinder = cylinderObject.GetComponent<FirstExerciseCylinderNotifier>();
        cylinder.OnCubeCollision += MoveSphere;
    }

    void MoveSphere()
    {
        if (CompareTag(type1Tag))
        {
            target = greenSphere;
        }
        else if (CompareTag(type2Tag))
        {
            target = cylinder.transform;
        }
    }

    void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        if (direction.magnitude > stoppingDistance)
        {
            rb.AddForce(direction.normalized * force, ForceMode.Acceleration);
        }
    }
}
