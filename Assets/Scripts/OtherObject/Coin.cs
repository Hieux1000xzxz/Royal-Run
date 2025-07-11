using UnityEngine;

public class Coin : Pickup
{
    ScoreManager scoreManager;
    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
    protected override void OnPickup()
    {
        if (scoreManager != null)
        {
            scoreManager.AddScore(10);
            Debug.Log("Coin picked up!");
        }
        else
        {
            Debug.LogWarning("ScoreManager is null in Coin!");
        }
    }
}
