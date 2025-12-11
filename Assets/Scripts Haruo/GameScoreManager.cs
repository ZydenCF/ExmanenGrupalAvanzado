using UnityEngine;

public class GameScoreManager : MonoBehaviour
{
    public static GameScoreManager Instance { get; private set; }

    private int runnerScore;
    private int ShooterScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddRunnerScore(int amount)
    {
        runnerScore += amount;
    }

    public void AddShooterScore(int amount)
    {
        ShooterScore += amount;
    }

    public int GetTotalScore()
    {
        return runnerScore + ShooterScore;
    }

    public int GetRunnerScore()
    {
        return runnerScore;
    }

    public int GetShooterScore()
    {
        return ShooterScore;
    }
}
