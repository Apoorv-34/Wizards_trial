using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); // scene at index 1
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}