using UnityEngine;
using TMPro;

internal class GameManager : MonoBehaviour
{
    private int score = 0;
    private float timeRemaining = 90f;
    private bool gameActive = true;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverPanel; 
    [SerializeField] private TextMeshProUGUI gameOverText; 

    private void Start()
    {
        UpdateScoreUI();
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (gameActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();

            if (timeRemaining <= 0f)
            {
                EndGame();
            }
        }
    }

    internal void AddScore(int points)
    {
        if (gameActive)
        {
            score += points;
            UpdateScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int seconds = Mathf.CeilToInt(timeRemaining);
            timerText.text = "Time: " + seconds.ToString() + "s";
        }
    }

    private void EndGame()
    {
        gameActive = false;

        // Activa el panel
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // Reactiva y cambia el texto
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true); 
            gameOverText.text = "Game Over!\nFinal Score: " + score.ToString();
        }
    }
}
