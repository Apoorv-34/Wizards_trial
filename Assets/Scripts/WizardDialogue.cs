using UnityEngine;

public class WizardDialogue : MonoBehaviour
{
    [TextArea] public string[] sentences; // Type your 4 lines here in Inspector
    
    private int index = 0;
    private bool isActive = false;

    // This function runs AUTOMATICALLY when the game starts (On Spawn)
    void Start()
    {
        // Check if we have any sentences written in the Inspector
        if (sentences.Length > 0)
        {
            // 1. Show the first message immediately
            SimpleChatBox.Instance.ShowMessage(sentences[0]);
            
            // 2. Allow the player to press Enter for the next lines
            isActive = true; 
        }
    }

    void Update()
    {
        // Only check for "Enter" if the dialogue is currently active
        if (isActive && Input.GetKeyDown(KeyCode.Return))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        index++; // Move to the next sentence number

        // If there are more sentences left...
        if (index < sentences.Length)
        {
            SimpleChatBox.Instance.ShowMessage(sentences[index]);
        }
        else
        {
            // If we ran out of sentences, close the box
            isActive = false;
            SimpleChatBox.Instance.HideMessage();
        }
    }
}