using UnityEngine;

public class NinthExerciseCubeMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private float horizontal;
    private float vertical;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rb.linearVelocity = new Vector3(movement.normalized.x * speed, rb.linearVelocity.y, movement.normalized.z * speed);
    }
}
