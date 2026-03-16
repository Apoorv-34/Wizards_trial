using UnityEngine;
using TMPro;

public class SimpleChatBox : MonoBehaviour
{
    public static SimpleChatBox Instance;

    [Header("UI References")]
    public GameObject panelObj;
    public TextMeshProUGUI textObj;

    private void Awake()
    {
        // Singleton Setup
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        HideMessage(); // Hide on start
    }

    // Function 1: Show text forever (for Wizard)
    public void ShowMessage(string message)
    {
        CancelInvoke("HideMessage"); // Stop timer if running
        textObj.text = message;
        panelObj.SetActive(true);
    }

    // Function 2: Show text with Timer (for Challenge)
    public void ShowMessage(string message, float duration)
    {
        ShowMessage(message); // Show text
        CancelInvoke("HideMessage");
        Invoke("HideMessage", duration); // Auto hide after time
    }

    public void HideMessage()
    {
        panelObj.SetActive(false);
    }
}