using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Flash : MonoBehaviour
{
    [ReadOnly]
    [SerializeField]
    private DialogueManager dialogueManager;

    [ReadOnly]
    public bool constantFlash = false;

    private void Awake()
    {
        dialogueManager = GetComponent<DialogueManager>();
    }

    private void Start()
    {
        Canvas.GetDefaultCanvasMaterial().color = Color.white;
    }

    //UI Flashing for feedback when player health value changes
    public IEnumerator Flash(Color flashColor)
    {
        dialogueManager.playerHealth.color = flashColor;
        yield return new WaitForSeconds(0.1f);
        dialogueManager.playerHealth.color = Color.white;
        yield return new WaitForSeconds(0.1f);
    }

    //UI flashing for low health status
    public IEnumerator ConstantFlash()
    {
        while(constantFlash)
        {
            Canvas.GetDefaultCanvasMaterial().color = Color.red;
            dialogueManager.dialogue.color = Color.red;
            dialogueManager.playerHealth.color = Color.red;
            yield return new WaitForSecondsRealtime(0.5f);
            Canvas.GetDefaultCanvasMaterial().color = Color.white;
            dialogueManager.dialogue.color = Color.white;
            dialogueManager.playerHealth.color = Color.white;
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
