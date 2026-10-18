using UnityEngine;

public class FourthExerciseProximityNotifier : MonoBehaviour
{
    public string playerTag = "Player";
    public float detectionDistance = 5f;
    public delegate void Message();
    public event Message OnPlayerApproaches;
    
    private Transform player;
    private bool playerNearby = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        player = playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionDistance && !playerNearby)
        {
            playerNearby = true;
            if (OnPlayerApproaches != null)
            {
                OnPlayerApproaches();
            }
        }
        else if (distance > detectionDistance)
        {
            playerNearby = false;
        }
    }
}
