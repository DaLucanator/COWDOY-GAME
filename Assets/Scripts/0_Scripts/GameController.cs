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
    private string microGameName;
    [ReadOnly]
    [SerializeField]
    private bool microGameWin = false;
    [ReadOnly]
    [SerializeField]
    private bool inMainScene = true;
    public Canvas canvas;


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

    private void Start()
    {
        //Test();
    }

    private void Test()
    {
        StartCoroutine(TestRoutine());
    }

    private IEnumerator TestRoutine()
    {
        sceneManager.pickMicrogame();
        yield return dialogueManager.TypeText(" Welcome to the main scene");
        yield return dialogueManager.TypeText("battle scene functionality not yet implemented");
        sceneManager.loadMicroGame();
    }

    public IEnumerator HealPlayer(int healAmount)
    {
        yield return healthManager.HealPlayer(healAmount);
    }

    public IEnumerator DamagePlayer(int damageAmount)
    {
        yield return healthManager.DamagePlayer(damageAmount);
    }

    public void DamageEnemyButton()
    {
        //shoot microgame goes here
        StartCoroutine(DamageEnemy(1));
    }

    public IEnumerator DamageEnemy(int damageAmount)
    {
        sceneManager.pickMicrogame();
        yield return healthManager.DamageEnemy(damageAmount);
        yield return dialogueManager.TypeText("Loading microgame " + sceneManager.gameToLoad.ToString());
        sceneManager.loadMicroGame();
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
        timer.TimerStop();
        microGameWin = win;
        SceneManager.LoadScene("0_BattleScene");
        GetCamera();
        dialogueManager.dialogue.text = "BATTLE";
        if(win == true) { StartCoroutine(playerWonMicro()); }
        else { StartCoroutine(playerLostMicro()); }
    }

    public void MicroGameStart(float startTime, bool isWinTimer, string microGameName, string microGameInstruction)
    {
        dialogueManager.dialogueLabel.text = microGameName;
        dialogueManager.dialogue.text = microGameInstruction;
        timer.TimerStart(startTime, isWinTimer);
    }

    private IEnumerator playerWonMicro()
    {
        sceneManager.pickMicrogame();
        yield return dialogueManager.TypeText("The Player won the microgame");
        yield return dialogueManager.TypeText("battle scene functionality not yet implemented");
        yield return dialogueManager.TypeText("Loading microgame " + sceneManager.gameToLoad);
        sceneManager.loadMicroGame();
    }

    private IEnumerator playerLostMicro()
    {
        sceneManager.pickMicrogame();
        yield return dialogueManager.TypeText("The Player lost the microgame");
        yield return DamagePlayer(1);
        yield return dialogueManager.TypeText("battle scene functionality not yet implemented");
        yield return dialogueManager.TypeText("Loading microgame " + sceneManager.gameToLoad);
        sceneManager.loadMicroGame();
    }



}
