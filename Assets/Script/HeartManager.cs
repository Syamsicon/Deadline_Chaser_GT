using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public static HeartManager Instance;

    [SerializeField] private Image[] hearts; // drag Heart1, Heart2, Heart3
    [SerializeField] private Sprite fullHeartSprite;
    [SerializeField] private Sprite brokenHeartSprite;
    [SerializeField] private GameObject gameOverPanel; // drag GameObject 'GameOverText' ke sini

    private int currentLives;
    private bool isGameOver = false;
    public static bool GameIsOver = false;

    void Awake()
    {
        Instance = this;
        currentLives = hearts.Length;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // pastiin nonaktif pas game mulai
    }

    public void LoseLife()
    {
        if (isGameOver) return; // udah game over, gak usah proses lagi

        currentLives--;

        // ganti sprite heart TERAKHIR yang masih penuh jadi broken
        if (currentLives >= 0 && currentLives < hearts.Length)
            hearts[currentLives].sprite = brokenHeartSprite;
        
        SFXManager.Instance.PlayHeartLossSound();

        Debug.Log("Life lost! Remaining: " + currentLives);

        if (currentLives <= 0)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        Debug.Log("GAME OVER!");

        WordSpawner.isGameOver = true;
        ScoreManager.Instance.DisplayFinalScore();

        if (gameOverPanel != null)
            gameOverPanel.transform.SetAsLastSibling();
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f; // hentikan semua gerakan (kata berhenti jatuh, dll)
    }

    // opsional: buat dipanggil dari tombol "Restart" nanti
    public void RestartGame()
    {
        Time.timeScale = 1f; // kembalikan waktu normal SEBELUM pindah scene
        WordSpawner.isGameOver = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}