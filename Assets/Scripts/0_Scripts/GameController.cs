using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour

    //this is the top layer of the game controller. In concept anytime a main game "manager" script.

{
    public static GameController current;

    [ReadOnly]
    [SerializeField]
    private DialogueManager dialogueManager;
    [ReadOnly]
    [SerializeField]
    private HealthManager healthManager;
    [ReadOnly]
    [SerializeField]
    private SceneManagerScript sceneManager;
    [ReadOnly]
    [SerializeField]
    private Timer timer;
    [ReadOnly]
    [SerializeField]
    private bool microGameWin = false;
    [ReadOnly]
    [SerializeField]
    private bool inMainScene = true;
    [SerializeField]
    private Texture2D cursor, crosshair;
    [SerializeField]
    private GameObject[] stuffToDisable;

    public Canvas canvas;
    public SceneData sceneData;

    [ReadOnly]
    public int healAmount, damageAmount;


    private void Awake()
    {
        if (FindObjectsOfType<GameController>().Length != 1) { Destroy(this.transform.parent.gameObject); }
        else 
        { 
            DontDestroyOnLoad(this.transform.parent.gameObject);
            current = this;
        }

        dialogueManager = GetComponent<DialogueManager>();
        healthManager = GetComponent<HealthManager>();
        sceneManager = GetComponent<SceneManagerScript>();
        timer = GetComponent<Timer>();
    }

    public IEnumerator HealPlayer(int healAmount)
    {
        sceneManager.pickMicrogame();
        yield return healthManager.HealPlayer(healAmount);
        yield return LoadMicro();
    }

    public IEnumerator DamagePlayer(int damageAmount)
    {
        yield return healthManager.DamagePlayer(damageAmount);
    }

    public void ShootButton()
    {
        sceneData = Resources.Load("WW_AttackTemp") as SceneData;
        sceneManager.gameToLoad = "WW_AttackTemp";
        StartCoroutine(LoadMicro());
    }

    public void HealButton()
    {
        sceneData = Resources.Load("WW_HealTemp") as SceneData;
        sceneManager.gameToLoad = "WW_HealTemp";
        StartCoroutine(LoadMicro());
    }

    public IEnumerator DamageEnemy(int damageAmount)
    {
        sceneManager.pickMicrogame();
        yield return healthManager.DamageEnemy(damageAmount);
        damageAmount = 0;
        yield return LoadMicro();
    }

    public void KillPLayer()
    { 
        Debug.Log("The PLayer is Dead");
    }

    public void GetCamera()
    {
        canvas.worldCamera = FindObjectOfType<Camera>();
    }

    public void ReturnToMain(bool win)
    {
        StartCoroutine(ReturnToMainStuff(false,win,false));
    }

    public void ReturnToMainAttackOrHeal(bool isAttack)
    {
        StartCoroutine(ReturnToMainStuff(true,false,isAttack));
    }

    private IEnumerator ReturnToMainStuff(bool isAttackOrHeal, bool win, bool isAttack)
    {
        timer.TimerStop();
        SetCursor("cursor");
        yield return dialogueManager.TypeText("returning to the main scene"); 
        SceneManager.LoadScene("0_BattleScene");
        GetCamera();
        dialogueManager.dialogueLabel.text = "BATTLE";
        enableThings(true);
        if (isAttackOrHeal)
        {
            if ((damageAmount + healAmount) <= 0) { yield return LoadMicro(); }
            else if (isAttack) { yield return DamageEnemy(damageAmount); }
            else { yield return HealPlayer(healAmount); }
        }
        else
        {
            if (win) { yield return playerWonMicro(); }
            else { yield return playerLostMicro(); }
        }
    }

    private void enableThings(bool enable)
    {
        foreach (GameObject disableMe in stuffToDisable)
        {
            disableMe.SetActive(enable);
        }
    }

    public void StartMicroGame()
    {
        SetCursor(sceneData.cursorMode);
        timer.TimerStart(sceneData.startTime, sceneData.isWinTimer);
    }

    private IEnumerator playerWonMicro()
    {
        yield return dialogueManager.TypeText("The Player won the microgame");
        dialogueManager.LoadButtons(true);
    }

    private IEnumerator playerLostMicro()
    {
        yield return dialogueManager.TypeText("The Player lost the microgame");
        yield return DamagePlayer(1);
        dialogueManager.LoadButtons(true);
    }

    private IEnumerator LoadMicro()
    {
        dialogueManager.dialogueLabel.text = sceneData.microGameName;
        yield return dialogueManager.TypeText("Loading microgame " + sceneData.microGameName);
        yield return dialogueManager.TypeText(sceneData.microGameInstruction);
        enableThings(false);
        sceneManager.loadMicroGame();
    }

    private void SetCursor(string cursorMode)
    {
        Vector2 cursorVector = new Vector2(0, 0); ;
        Texture2D cursorTex = cursor;

        if (cursorMode == "crosshair")
        {
            cursorVector = new Vector2(16, 16);
            cursorTex = crosshair;
        }
        if(cursorMode == "off") { Cursor.visible = false; }
        else { Cursor.visible = true; }

        Cursor.SetCursor(cursorTex, cursorVector, CursorMode.Auto);
    }


}
