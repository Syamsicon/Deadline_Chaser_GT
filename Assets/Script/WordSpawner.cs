// WordSpawner.cs — baru
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    [SerializeField] private float[] laneXPosition = {-700, 0, 700}; //randomizer position
    [SerializeField] private GameObject wordPrefab; // drag prefab "Text (TMP)" ke sini
    [SerializeField] private Transform canvasTransform; // drag Canvas ke sini
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
        Lane[] lanes = { Lane.Left, Lane.Center, Lane.Right };
        int laneIndex = Random.Range(0, lanes.Length);
        Lane ChoosenLane = lanes[laneIndex];

        GameObject newWord = Instantiate(wordPrefab, canvasTransform);
        RectTransform rt = newWord.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(laneXPosition[laneIndex], spawnPosition.y);

        string randomWord = wordList[Random.Range(0, wordList.Length)];
        TypingManager tm = newWord.GetComponent<TypingManager>();
        tm.MyLane = ChoosenLane;
        tm.SetWord(randomWord);

    }
}