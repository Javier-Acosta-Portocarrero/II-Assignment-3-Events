
using UnityEngine;

public class NinthExerciseCubeMovement : MonoBehaviour
{
    public float force = 15f;
    private Rigidbody rb;
    private float horizontal;
    private float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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
        rb.AddForce(movement.normalized * force, ForceMode.Acceleration);
    }
}
