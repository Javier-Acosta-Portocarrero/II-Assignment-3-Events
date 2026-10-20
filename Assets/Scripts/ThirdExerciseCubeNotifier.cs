using UnityEngine;

public class ThirdExerciseCubeNotifier : MonoBehaviour
{
    public string type1Tag = "Type1";
    public string type2Tag = "Type2";

    public delegate void Message();
    public event Message OnType1Collision;
    public event Message OnType2Collision;

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
        if (collision.gameObject.CompareTag(type1Tag))
        {
            //Debug.Log("The cube collided with a Type1 humanoid");
            if (OnType1Collision != null)
            {
                OnType1Collision();
            }
        }
        else if (collision.gameObject.CompareTag(type2Tag))
        {
            //Debug.Log("The cube collided with a Type2 humanoid");
            if (OnType2Collision != null)
            {
                OnType2Collision();
            }
        }
    }
}
