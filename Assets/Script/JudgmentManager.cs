using UnityEngine;
using TMPro;

public enum JudgmentType { Perfect, Good, Bad, Miss }

public class JudgmentManager : MonoBehaviour
{
    public static JudgmentManager Instance;

    [SerializeField] private GameObject perfectText;
    [SerializeField] private GameObject goodText;
    [SerializeField] private GameObject badText;
    [SerializeField] private GameObject missText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private float displayDuration = 0.6f; // berapa lama judgment keliatan sebelum ilang

    private int currentCombo = 0;

    void Awake()
    {
        Instance = this;
        HideAll();
        UpdateComboText();
    }

    public void ShowJudgment(JudgmentType type)
    {
        HideAll();

        switch (type)
        {
            case JudgmentType.Perfect:
                perfectText.SetActive(true);
                currentCombo++;
                ScoreManager.Instance.AddScore(100);
                break;
            case JudgmentType.Good:
                goodText.SetActive(true);
                currentCombo++;
                ScoreManager.Instance.AddScore(75);
                break;
            case JudgmentType.Bad:
                badText.SetActive(true);
                currentCombo++;
                ScoreManager.Instance.AddScore(50);
                break;
            case JudgmentType.Miss:
                missText.SetActive(true);
                currentCombo = 0; // combo reset kalau miss
                break;
        }

        UpdateComboText();
        CancelInvoke(nameof(HideAll));
        Invoke(nameof(HideAll), displayDuration);
    }

    void HideAll()
    {
        perfectText.SetActive(false);
        goodText.SetActive(false);
        badText.SetActive(false);
        missText.SetActive(false);
    }

    void UpdateComboText()
    {
        if (comboText != null) comboText.text = currentCombo.ToString();
    }
}