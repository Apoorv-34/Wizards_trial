using UnityEngine;
using UnityEngine.SceneManagement; // Required to switch scenes

public class LevelMove : MonoBehaviour
{
    [Tooltip("Type the exact name of the scene you want to load here")]
    public string sceneName;

    // This function runs when the player enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding is the Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered finish zone. Loading scene...");
            SceneManager.LoadScene(sceneName);
        }
    }
}