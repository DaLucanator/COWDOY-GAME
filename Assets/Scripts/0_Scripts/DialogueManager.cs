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
    private GameObject buttons, dialogueObject;

    [SerializeField]
    private GameObject continueImage;

    [SerializeField]
    private float typeDelay;

    private bool continueBool = false;
    private bool continueCheck = false;

    private void Awake()
    {
        ui_Flash = GetComponent<UI_Flash>();
        continueImage.SetActive(false);
        dialogue.text = "";
        dialogueObject.SetActive(false);
    }

    private void Update()
    {
        if (continueCheck)
        {
            if (Input.anyKeyDown)
            {
                continueBool = true;
                continueCheck = false;
            }
        }
    }

    public IEnumerator TypeText(string dialogueText)
    {
        buttons.SetActive(false);
        dialogueObject.SetActive(true);

        dialogue.text = "";

        foreach(char letter in dialogueText.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSecondsRealtime(typeDelay);
        }
        continueCheck = true;
        continueImage.SetActive(true);
        yield return new WaitUntil(() => continueBool == true);
        continueBool = false;
        continueCheck = false;
        continueImage.SetActive(false);
    }

    public void LoadButtons()
    {
        dialogue.text = "";
        dialogueObject.SetActive(false);
        buttons.SetActive(true);
    }

}
