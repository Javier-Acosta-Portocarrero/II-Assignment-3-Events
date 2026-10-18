using UnityEngine;

public class FirstExerciseCylinderNotifier : MonoBehaviour
{
    public string playerTag = "Player";
    public delegate void Message();
    public event Message OnCubeCollision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            Debug.Log("The cube collided with the cylinder");
            if (OnCubeCollision != null)
            {
                OnCubeCollision();
            }
        }
    }
}
