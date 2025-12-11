using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManagerRunner : MonoBehaviour
{
    public static GameManagerRunner Instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMPro.TextMeshProUGUI scoreUI;
    private ObstacleSpawner a;
    private const string runnerKey = "KeyRunner";
    public string RunnerKey => runnerKey;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        a = FindAnyObjectByType<ObstacleSpawner>();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        scoreUI.text = $"Score: " + a.Score.ToString();
        PlayerPrefs.SetInt (runnerKey, a.Score);
        gameOverPanel.SetActive(true);
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }
}
