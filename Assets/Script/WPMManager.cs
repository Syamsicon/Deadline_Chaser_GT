using UnityEngine;
using TMPro;

public class WPMManager : MonoBehaviour
{
    public static WPMManager Instance;

    [SerializeField] private TextMeshProUGUI wpmText;

    private float wpmSum = 0f;
    private int wordsCompleted = 0;

    void Awake()
    {
        Instance = this;
        UpdateWPMText();
    }

    public void AddCompletedWord(float timeTakenSeconds)
    {
        if (timeTakenSeconds <= 0f) timeTakenSeconds = 0.01f; // jaga-jaga dari pembagian nol

        float wordWpm = 60f / timeTakenSeconds;
        wpmSum += wordWpm;
        wordsCompleted++;

        UpdateWPMText();
    }

    void UpdateWPMText()
    {
        int avgWpm = wordsCompleted > 0 ? Mathf.RoundToInt(wpmSum / wordsCompleted) : 0;
        if (wpmText != null) wpmText.text = avgWpm.ToString();
    }
}