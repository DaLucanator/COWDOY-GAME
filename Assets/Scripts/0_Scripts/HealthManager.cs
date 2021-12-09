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

    [SerializeField]
    private GameObject healthBar,damageBar;

    [ReadOnly]
    [SerializeField]
    public SpriteRenderer damageBarSprite,healthBarSprite;

    public SpriteRenderer healthBarFrame;


    private void Awake()
    {
        ui_Flash = GetComponent<UI_Flash>();
        dialogueManager = GetComponent<DialogueManager>();
        damageBarSprite = damageBar.GetComponent<SpriteRenderer>();
        healthBarSprite = healthBar.GetComponent<SpriteRenderer>();

        playerHealth = playerInitialHealth;
        enemyHealth = enemyInitialHealth;
    }

    private void Start()
    {
        dialogueManager.playerHealth.text = playerHealth.ToString();
    }

    public IEnumerator HealPlayer(int healAmount)
    {
        ui_Flash.constantFlashLowHealth = false;

        for(int i = 0; i <= healAmount; i++)
        {

            if (playerHealth >= playerMaxHealth)
            {
                if(i == 0) { yield return ui_Flash.Flash(Color.cyan, "player"); }
                playerHealth = playerMaxHealth;
                yield return dialogueManager.TypeText(("The  player  regained  " + i.ToString() + "  health  and  reached  maximum  vitality"));
                yield return new WaitForSeconds(0.5f);
                break;
            }

            yield return ui_Flash.Flash(Color.cyan, "player");
            playerHealth++;
            dialogueManager.playerHealth.text = playerHealth.ToString();
            
            if(i == healAmount) { yield return dialogueManager.TypeText(("The  player  regained  " + healAmount.ToString() + "  health")); }

        }
        CheckHealth();
    }

    public IEnumerator DamagePlayer(int damageAmount)
    {
        ui_Flash.constantFlashLowHealth = false;

        for (int i = 1; i <= damageAmount; i++)
        {

            if (playerHealth <= 0)
            {
                yield return dialogueManager.TypeText(("The  player  took  " + i.ToString() + "  damage and died"));
                break;
            }

            yield return ui_Flash.Flash(Color.red, "player");
            playerHealth--;
            dialogueManager.playerHealth.text = playerHealth.ToString();

            if (i == damageAmount) { yield return dialogueManager.TypeText(("The  Cowboy  took  " + damageAmount.ToString() + "  damage")); }
        }

        CheckHealth();
    }

    public IEnumerator DamageEnemy(int damageAmount)
    {
        for (int i = 1; i <= damageAmount; i++)
        {

            if (enemyHealth <= 0)
            {
                yield return dialogueManager.TypeText(("The  Stranger  took  " + i.ToString() + "  damage and died"));
                break;
            }

            yield return ui_Flash.Flash(Color.red, "enemy");
            //add shake effect
            enemyHealth--;

            if (i == damageAmount) 
            {
                DamageBarEffect(damageAmount);
                ui_Flash.constantFlashDamageEnemy = true;
                StartCoroutine(ui_Flash.ConstantFlash("damageEnemy"));
                yield return dialogueManager.TypeText(("The  Stranger  took  " + damageAmount.ToString() + "  damage"));
                ui_Flash.constantFlashDamageEnemy = false;
            }
        }
        HealthBarRescale();
        //CheckHealth(); check enemy health
    }

    private void CheckHealth()
    {
        if (playerHealth <= 0) { GameController.current.KillPLayer(); }
        if (playerHealth <= playerHealthLow) 
        { 
            ui_Flash.constantFlashLowHealth = true;
            StartCoroutine(ui_Flash.ConstantFlash("lowHealth"));
        }
    }

    private void DamageBarEffect(int damageAmount)
    {
        Vector3 scale = new Vector3(((enemyMaxHealth/100) * damageAmount), 1, 1);
        Vector3 pos = new Vector3(0.5f - (enemyMaxHealth / 100), 4.2f, -2);
        damageBar.transform.localScale = scale;
        damageBar.transform.localPosition = pos;
    }
    private void HealthBarRescale()
    {
        Vector3 scale = new Vector3 ((enemyMaxHealth / 100) * enemyHealth, 1, 1);
        Vector3 pos = new Vector3 (-3.3f - ((enemyMaxHealth / 100) * enemyHealth), 4.2f, -1);
        healthBar.transform.localScale = scale;
        healthBar.transform.localPosition = pos;
    }
}
