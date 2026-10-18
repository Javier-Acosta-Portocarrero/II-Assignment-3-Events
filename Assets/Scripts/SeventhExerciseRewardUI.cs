using UnityEngine;
using UnityEngine.UI;

public class SeventhExerciseRewardUI : MonoBehaviour
{
    public Text rewardText;

    private FifthExerciseShieldCollector collector;
    private int rewards = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collector = GetComponent<FifthExerciseShieldCollector>();
        UpdateRewardText();
    }

    // Update is called once per frame
    void Update()
    {
         CheckRewards();
    }

    void CheckRewards()
    {
        int newRewards = collector.GetScore() / 100;
        if (newRewards > rewards)
        {
            rewards = newRewards;
            UpdateRewardText();
        }
    }

    void UpdateRewardText()
    {
        rewardText.text = "Rewards: " + rewards;
    }
}
