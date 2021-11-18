using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [ReadOnly]
    [SerializeField]
    private UI_Flash ui_Flash;
    [ReadOnly]
    [SerializeField]
    private DialogueManager dialogueManager;

    [ReadOnly]
    [SerializeField]
    private int playerHealth, enemyHealth;
    [SerializeField]
    private int playerMaxHealth, enemyMaxHealth, playerInitialHealth, enemyInitialHealth, playerHealthLow;

    private void Awake()
    {
        ui_Flash = GetComponent<UI_Flash>();
        dialogueManager = GetComponent<DialogueManager>();

        playerHealth = playerInitialHealth;
        enemyHealth = enemyInitialHealth;
    }

    private void Start()
    {
        dialogueManager.playerHealth.text = playerHealth.ToString();

        StartCoroutine(ui_Flash.ConstantFlash());

        if (playerHealth < playerHealthLow) 
        { 
            ui_Flash.constantFlash = true;
        }

    }

    public IEnumerator HealPlayer(int healAmount)
    {
        ui_Flash.constantFlash = false;

        for(int i = 0; i <= healAmount; i++)
        {

            if (playerHealth >= playerMaxHealth)
            {
                if(i == 0) { yield return ui_Flash.Flash(Color.cyan); }
                playerHealth = playerMaxHealth;
                yield return dialogueManager.TypeText(("The  player  regained  " + i.ToString() + "  health  and  reached  maximum  vitality"));
                yield return new WaitForSeconds(0.5f);
                break;
            }

            yield return ui_Flash.Flash(Color.cyan);
            playerHealth++;
            dialogueManager.playerHealth.text = playerHealth.ToString();
            
            if(i == healAmount) { yield return dialogueManager.TypeText(("The  player  regained  " + healAmount.ToString() + "  health")); }

        }
        CheckHealth();
    }

    public IEnumerator DamagePlayer(int damageAmount)
    {
        ui_Flash.constantFlash = false;

        for (int i = 1; i <= damageAmount; i++)
        {

            if (playerHealth <= 0)
            {
                yield return dialogueManager.TypeText(("The  player  took  " + i.ToString() + "  damage and died"));
                break;
            }

            yield return ui_Flash.Flash(Color.red);
            playerHealth--;
            dialogueManager.playerHealth.text = playerHealth.ToString();

            if (i == damageAmount) { yield return dialogueManager.TypeText(("The  player  took  " + damageAmount.ToString() + "  damage")); }
        }

        CheckHealth();
    }

    private void CheckHealth()
    {
        if (playerHealth <= 0) { GameController.current.KillPLayer(); }
        if (playerHealth <= playerHealthLow) 
        { 
            ui_Flash.constantFlash = true;
            StartCoroutine(ui_Flash.ConstantFlash());
        }
    }
}
