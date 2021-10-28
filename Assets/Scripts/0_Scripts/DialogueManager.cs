using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    [ReadOnly]
    [SerializeField]
    private UI_Flash ui_Flash;

    public TextMeshProUGUI dialogue, dialogueLabel, playerHealth;

    [SerializeField]
    private GameObject buttons;

    [SerializeField]
    private float typeDelay;

    private void Start()
    {
        dialogue.text = "";
    }

    private void Awake()
    {
        ui_Flash = GetComponent<UI_Flash>();
    }

    public IEnumerator TypeText(string dialogueText, string dialogueLabelText)
    {
        buttons.SetActive(false);

        dialogueLabel.text = dialogueLabelText;
        dialogue.text = "";

        foreach(char letter in dialogueText.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSecondsRealtime(typeDelay);
        }

        yield return new WaitForSeconds(1f);
    }

    public void LoadButtons()
    {
        dialogue.text = "";
        buttons.SetActive(true);
    }

}
