using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Gameplay"); // harus SAMA PERSIS nama scene-nya
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // opsional: kalau mau reusable buat scene manapun tanpa bikin function baru tiap kali
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}