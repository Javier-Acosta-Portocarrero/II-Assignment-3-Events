using UnityEngine;

public class FifthExerciseShieldCollector : MonoBehaviour
{
    public string shieldType1Tag = "ShieldType1";
    public string shieldType2Tag = "ShieldType2";
    
    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore()
    {
        return score;
    } 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(shieldType1Tag))
        {
            score += 5;
            Debug.Log("Score: " + score);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag(shieldType2Tag))
        {
            score += 10;
            Debug.Log("Score: " + score);
            Destroy(collision.gameObject);
        }
    }
}
