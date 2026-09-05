// TypingManager.cs — updated version
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Lane {Left, Center, Right};

public class TypingManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wordText;
    [SerializeField] private string targetWord = "Obey";
    [SerializeField] private float moveSpeed = 100f; 
    
    public Lane MyLane;
    public static Transform missLineRef;

    //Q-ing lane closest to missLine
    public static List<TypingManager> LeftQueue = new List<TypingManager>();
    public static List<TypingManager> CenterQueue = new List<TypingManager>();
    public static List<TypingManager> RightQueue = new List<TypingManager>();
    
    private int typedIndex = 0;
    private RectTransform rectTransform;

    void Start()
    {
        if (wordText == null)
            wordText = GetComponent<TextMeshProUGUI>();

        rectTransform = GetComponent<RectTransform>();
        wordText.text = targetWord;
        typedIndex = 0;

        GetQueue().Add(this);
    }

    void OnDestroy()
    {
        GetQueue().Remove(this);
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

        if (MyLane != LaneSwitcher.CurrentActiveLane) return;
        if (!IsFrontOfQueue()) return;

        foreach (char c in Input.inputString)
        {
            if (c == '\b' || c == '\n' || c == '\r') continue;
            CheckTypedChar(c);
        }
    }

    List<TypingManager> GetQueue()
    {
        return MyLane switch
        {
            Lane.Left => LeftQueue,
            Lane.Center => CenterQueue,
            _ => RightQueue,
        };
    }

    bool IsFrontOfQueue()
    {
        var q = GetQueue();
        return q.Count > 0 && q[0] == this;
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