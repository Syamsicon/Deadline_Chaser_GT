// TypingManager.cs — updated version
using UnityEngine;
using TMPro;

public class TypingManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wordText;
    [SerializeField] private string targetWord = "Obey";
    [SerializeField] private float moveSpeed = 150f; 
    public static Transform missLineRef;

    private int typedIndex = 0;
    private RectTransform rectTransform;

    public static TypingManager ActiveWord; // biar cuma 1 kata yang nerima input dulu (simplifikasi awal)

    void Start()
    {
        if (wordText == null)
            wordText = GetComponent<TextMeshProUGUI>();

        rectTransform = GetComponent<RectTransform>();
        wordText.text = targetWord;
        typedIndex = 0;

        ActiveWord = this; // set kata ini sebagai yang lagi bisa diketik
    }

    void Update()
    {
        // gerak ke bawah tiap frame
        rectTransform.anchoredPosition += Vector2.down * moveSpeed * Time.deltaTime;

        // cek kalau udah lewat batas atas = miss
        if (missLineRef != null && transform.position.y <= missLineRef.position.y)
        {
            Debug.Log("Miss! Word reached the line: " + targetWord);
            Destroy(gameObject);
            return;
        }

        if (ActiveWord != this) return;

        foreach (char c in Input.inputString)
        {
            if (c == '\b' || c == '\n' || c == '\r') continue;
            CheckTypedChar(c);
        }
    }

    public void SetWord(string newWord)
    {
        targetWord = newWord;
        typedIndex = 0;
        if (wordText != null) wordText.text = targetWord;
    }

    void CheckTypedChar(char typedChar)
    {
        if (typedIndex >= targetWord.Length) return;

        char expectedChar = targetWord[typedIndex];

        if (char.ToLower(typedChar) == char.ToLower(expectedChar))
        {
            typedIndex++;
            UpdateWordDisplay();

            if (typedIndex >= targetWord.Length)
            {
                Debug.Log("Word Complete! " + targetWord);
                ActiveWord = null;
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("Miss! expected: " + expectedChar + " got: " + typedChar);
        }
    }

    void UpdateWordDisplay()
    {
        string typedPart = targetWord.Substring(0, typedIndex);
        string remainingPart = targetWord.Substring(typedIndex);
        wordText.text = $"<color=#888888>{typedPart}</color>{remainingPart}";
    }
}