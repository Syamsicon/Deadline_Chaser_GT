using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    private int currentScore = 0;

    void Awake()
    {
        Instance = this;
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null) scoreText.text = currentScore.ToString();
    }

    public void DisplayFinalScore()
    {
        if (finalScoreText != null) finalScoreText.text = currentScore.ToString();
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreText();
    }
}