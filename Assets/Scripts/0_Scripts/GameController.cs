using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour

    //this is the top layer of the game controller. In concept anytime a main game "manager" script needed to talk to another it would do it through here.

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
    private string microGameName;
    [ReadOnly]
    [SerializeField]
    private bool microGameWin = false;


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
    }

    private void Start()
    {
        Test();
    }

    private void Test()
    {
        StartCoroutine(TestRoutine());
    }

    private IEnumerator TestRoutine()
    {
        sceneManager.pickMicrogame();
        yield return dialogueManager.TypeText(" Welcome to the main scene", "BATTLE");
        yield return dialogueManager.TypeText("battle scene functionality not yet implemented", "BATTLE");
        yield return dialogueManager.TypeText("Loading microgame " + sceneManager.gameToLoad.ToString(), "BATTLE");
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

    public void KillPLayer()
    {
        Debug.Log("The PLayer is Dead");
    }

    public void ReturnToMain(bool win)
    {
        microGameWin = win;
        SceneManager.LoadScene("0_BattleScene");
        if(win == true) { StartCoroutine(playerWonMicro()); }
        else { StartCoroutine(playerLostMicro()); }
    }

    private IEnumerator playerWonMicro()
    {
        sceneManager.pickMicrogame();
        yield return dialogueManager.TypeText("The Player won the microgame", "BATTLE");
        yield return dialogueManager.TypeText("battle scene functionality not yet implemented", "BATTLE");
        yield return dialogueManager.TypeText("Loading microgame " + sceneManager.gameToLoad, "BATTLE");
        sceneManager.loadMicroGame();
    }

    private IEnumerator playerLostMicro()
    {
        sceneManager.pickMicrogame();
        yield return dialogueManager.TypeText("The Player lost the microgame", "BATTLE");
        yield return DamagePlayer(1);
        yield return dialogueManager.TypeText("battle scene functionality not yet implemented", "BATTLE");
        yield return dialogueManager.TypeText("Loading microgame " + sceneManager.gameToLoad, "BATTLE");
        sceneManager.loadMicroGame();
    }

}
