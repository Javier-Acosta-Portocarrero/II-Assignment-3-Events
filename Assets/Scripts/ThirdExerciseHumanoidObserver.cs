using UnityEngine;

public class ThirdExerciseHumanoidObserver : MonoBehaviour
{
    public string playerTag = "Player";
    public string type1Tag = "Type1";
    public string shieldType1Tag = "ShieldType1";
    public string shieldType2Tag = "ShieldType2";
    public Transform selectedShield;
    public float speed = 3f;

    private Rigidbody rb;
    private ThirdExerciseCubeNotifier notifier;
    private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        notifier = player.GetComponent<ThirdExerciseCubeNotifier>();

        notifier.OnType1Collision += MoveToType2Shield;
        notifier.OnType2Collision += MoveToSelectedShield;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Vector3 movement = direction.normalized * speed;

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
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
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            Debug.Log(gameObject.name + " changed color");
        }
    }
}
