using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Flash : MonoBehaviour
{
    [ReadOnly]
    [SerializeField]
    private DialogueManager dialogueManager;
    [ReadOnly]
    [SerializeField]
    private HealthManager healthManager;

    [ReadOnly]
    public bool constantFlashLowHealth = false, constantFlashDamageEnemy = false;

    private void Awake()
    {
        dialogueManager = GetComponent<DialogueManager>();
        healthManager = GetComponent<HealthManager>();
    }

    private void Start()
    {
        Canvas.GetDefaultCanvasMaterial().color = Color.white;
    }

    //UI "Flash" for feedback when damage is taken
    public IEnumerator Flash(Color flashColor, string target)
    {
        if(target == "player")
        {
            Canvas.GetDefaultCanvasMaterial().color = flashColor;
            dialogueManager.dialogue.color = flashColor;
            dialogueManager.playerHealth.color = flashColor;
            yield return new WaitForSeconds(0.5f);
            Canvas.GetDefaultCanvasMaterial().color = Color.white;
            dialogueManager.dialogue.color = Color.white;
            dialogueManager.playerHealth.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }

        if (target == "enemy")
        {
            healthManager.healthBarFrame.color = flashColor;
            healthManager.healthBarSprite.color = flashColor;
            healthManager.damageBarSprite.color = flashColor;
            yield return new WaitForSeconds(0.5f);
            healthManager.healthBarFrame.color = Color.white;
            healthManager.healthBarSprite.color = Color.white;
            healthManager.damageBarSprite.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
    }


    //Constant version of health flashing
    public IEnumerator ConstantFlash(string mode)
    {
        while(constantFlashLowHealth && mode == "lowHealth")
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

        while (constantFlashDamageEnemy && mode == "damageEnemy")
        {
            healthManager.damageBarSprite.color = Color.red;
            yield return new WaitForSecondsRealtime(0.5f);
            healthManager.damageBarSprite.color = Color.black;
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
