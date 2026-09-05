// WordSpawner.cs — baru
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    [SerializeField] private float[] laneXPosition = {-350, 0, 350}; //randomizer position
    [SerializeField] private GameObject wordPrefab;
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private string[] wordList = { "Obey", "Fly", "Type", "Deadline", "Focus" };
    [SerializeField] private float spawnInterval = 0.2f; // detik antar spawn
    [SerializeField] private Vector2 spawnPosition = new Vector2(0f, 400f); // posisi awal atas
    [SerializeField] private Transform missLine;

    void Start()
    {
        TypingManager.missLineRef = missLine;
        InvokeRepeating(nameof(SpawnWord), 1f, spawnInterval);
    }

    void SpawnWord()
    {
        int laneIndex = Random.Range(0, laneXPosition.Length); // 0=left, 1=center, 2=right
        Lane ChoosenLane = (Lane)laneIndex;

        GameObject newWord = Instantiate(wordPrefab, canvasTransform);
        RectTransform rt = newWord.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(laneXPosition[laneIndex], spawnPosition.y);

        string randomWord = wordList[Random.Range(0, wordList.Length)];
        TypingManager tm = newWord.GetComponent<TypingManager>();
        tm.MyLane = ChoosenLane;
        tm.SetWord(randomWord);

    }
}