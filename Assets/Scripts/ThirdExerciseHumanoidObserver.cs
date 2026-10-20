
using UnityEngine;

public class ThirdExerciseHumanoidObserver : MonoBehaviour
{
    public string playerTag = "Player";
    public string type1Tag = "Type1";
    public string shieldType2Tag = "ShieldType2";
    public Transform selectedShield;
    public float force = 10f;

    private Rigidbody rb;
    private ThirdExerciseCubeNotifier notifier;
    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        notifier = player.GetComponent<ThirdExerciseCubeNotifier>();

        notifier.OnType1Collision += MoveToType2Shield;
        notifier.OnType2Collision += MoveToSelectedShield;
    }

    void MoveToSelectedShield()
    {
        if (!CompareTag(type1Tag))
            return;

        target = selectedShield;
    }

    void MoveToType2Shield()
    {
        if (!CompareTag(type1Tag))
            return;

        GameObject[] shields = GameObject.FindGameObjectsWithTag(shieldType2Tag);
        float minDistance = Mathf.Infinity;

        foreach (GameObject shield in shields)
        {
            float distance = Vector3.Distance(transform.position, shield.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                target = shield.transform;
            }
        }
    }

    void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0;

        rb.AddForce(direction.normalized * force, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(shieldType2Tag))
        {
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer characterRenderer in renderers)
            {
                characterRenderer.material.color = Color.yellow;
            }
            target = null;
            //Debug.Log(gameObject.name + " changed color");
        }
    }
}
