using UnityEngine;

public class FourthExerciseHumanoidObserver : MonoBehaviour
{
    public string referenceTag = "Reference";
    public string type1Tag = "Type1";
    public string type2Tag = "Type2";
    public Transform selectedShield;
    public Transform orientationTarget;
    public Vector3 teleportOffset = new Vector3(0, 0, 2);

    private Rigidbody rb;
    private FourthExerciseProximityNotifier notifier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject referenceObject = GameObject.FindGameObjectWithTag(referenceTag);
        notifier = referenceObject.GetComponent<FourthExerciseProximityNotifier>();
        notifier.OnPlayerApproaches += RespondToApproach;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RespondToApproach()
    {
        if (CompareTag(type1Tag))
        {
            TeleportToShield();
        }
        else if (CompareTag(type2Tag))
        {
            LookAtTarget();
        }
    }

    void TeleportToShield()
    {
        if (selectedShield == null)
            return;

        rb.position = selectedShield.position + teleportOffset;
    }

    void LookAtTarget()
    {
        if (orientationTarget == null)
            return;

        Vector3 targetPosition = orientationTarget.position;
        targetPosition.y = transform.position.y;

        transform.LookAt(targetPosition);
    }
}
