using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1ToScene2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}