using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused = false;

    [SerializeField] private GameObject pausePanel;

    void Update()
    {
        if (HeartManager.GameIsOver) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        if (pausePanel != null)
        {
            pausePanel.transform.SetAsLastSibling();
            pausePanel.SetActive(true);
        }
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    public void ExitToMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}