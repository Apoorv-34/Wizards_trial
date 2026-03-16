using UnityEngine;
using UnityEngine.SceneManagement; // Required to change scenes

public class FallReset : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip(" The Y position at which the scene will reload. Usually a negative number.")]
    [SerializeField] private float fallThreshold = -10f;

    [Tooltip("The exact name of the scene you want to load.")]
    [SerializeField] private string sceneToLoad = "home";

    void Update()
    {
        // Check if the player's Y position is lower than the threshold
        if (transform.position.y < fallThreshold)
        {
            LoadTargetScene();
        }
    }

    void LoadTargetScene()
    {
        // check if the scene exists in build settings to prevent errors
        if (Application.CanStreamedLevelBeLoaded(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Scene '" + sceneToLoad + "' not found! Check your Build Settings.");
        }
    }
}