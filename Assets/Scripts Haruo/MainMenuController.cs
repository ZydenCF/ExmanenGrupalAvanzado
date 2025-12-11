using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private TMPro.TextMeshProUGUI runnerScoreText;
    [SerializeField] private TMPro.TextMeshProUGUI ShooterScoreText;
    [SerializeField] private TMPro.TextMeshProUGUI totalScoreText;

    public void LoadShooterMinnigame()
    {
        SceneManager.LoadScene("LevelShooter");
    }

    public void LoadRunnerMinigame()
    {
        SceneManager.LoadScene("LevelRunner");
    }

    public void ShowScores()
    {
        scorePanel.SetActive(true);

        int runner = PlayerPrefs.GetInt("KeyRunner", 0);
        int shooter = PlayerPrefs.GetInt("ShooterKey", 0);
        int total = runner + shooter;
        runnerScoreText.text = "Runner Score: " + runner;
        ShooterScoreText.text = "Shooter Score: " + shooter;
        totalScoreText.text = "Total Score: " + total;
        
    }

    public void CloseScores()
    {
        scorePanel.SetActive(false);
    }
}
