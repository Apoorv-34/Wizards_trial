using UnityEngine;
using UnityEngine.SceneManagement; // Required to change scenes
using System.Collections;

public class AutoRedirect : MonoBehaviour
{
    [Header("Settings")]
    public string homeSceneName = "Main Scene"; // Type the EXACT name of your home scene here
    public float delayInSeconds = 5f;

    void Start()
    {
        // This runs automatically when the scene starts
        StartCoroutine(RedirectRoutine());
    }

    IEnumerator RedirectRoutine()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(delayInSeconds);

        // Load the home scene
        SceneManager.LoadScene(homeSceneName);
    }
}