using TMPro;
using UnityEngine;
using UnityEngine.UI;   

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] float startTime = 5f;
    [SerializeField] GameObject GameOverText;
    [SerializeField] PlayerController playerController;
    public static GameManager Instance { get; private set; }
    float timeLeft; 
    private bool gameOver = false;
    public bool IsGameOver => gameOver;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        timeLeft = startTime;
        
    }

    void Update()
    {
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        if (gameOver) return;
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");
        if (timeLeft <= 0)
        {
            GameOver();
        }
    }
    public void IncreaseTime(float timeExtention)
    {
        timeLeft += timeExtention;
    }
    void GameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        GameOverText.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
