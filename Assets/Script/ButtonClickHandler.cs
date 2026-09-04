using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickHandler : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "Gameplay";

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}