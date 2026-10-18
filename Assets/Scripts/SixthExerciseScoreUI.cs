using UnityEngine;
using UnityEngine.UI;

public class SixthExerciseScoreUI : MonoBehaviour
{
    public string playerTag = "Player";
    public Text scoreText;

    private FifthExerciseShieldCollector collector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collector = GetComponent<FifthExerciseShieldCollector>();
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
    
    private void UpdateScore()
    {
        scoreText.text = "Score: " + collector.GetScore();
    }
}
