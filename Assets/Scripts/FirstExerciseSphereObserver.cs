using UnityEngine;

public class FirstExerciseSphereObserver : MonoBehaviour
{
    public string cylinderTag = "Cylinder";
    public string type1Tag = "Type1";
    public string type2Tag = "Type2";
    public Transform greenSphere;
    public float speed = 3f;
    public float stoppingDistance = 3f;

    private Rigidbody rb;
    private FirstExerciseCylinderNotifier cylinder;
    private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject cylinderObject = GameObject.FindWithTag(cylinderTag);
        cylinder = cylinderObject.GetComponent<FirstExerciseCylinderNotifier>();
        cylinder.OnCubeCollision += MoveSphere;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveSphere()
    {
        if (CompareTag("Type1"))
        {
            target = greenSphere;
        }
        else if (CompareTag("Type2"))
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
            rb.velocity = direction.normalized * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
