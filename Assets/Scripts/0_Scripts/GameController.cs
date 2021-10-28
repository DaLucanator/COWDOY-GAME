using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour

// I (Luc) have come to the conclusion, that due to wanting to orchestrate pauses between events via coroutines, that our project is better off without an observer pattern.
// When using events things got complex: I needed events for both the start and end of each coroutine sometimes or lots of bools (at least the way I was doing it)
//I'm using a singleton pattern. Our project is small enough that dependencies aren't a problem. The dependencies are limited and don't branch too far.

//it's actually a mess now that it's done lmao

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
    private bool currentGameWin = false;


    private void Awake()
    {
        current = this;
        dialogueManager = GetComponent<DialogueManager>();
        healthManager = GetComponent<HealthManager>();
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
        yield return dialogueManager.TypeText("This  is  a  test  of  several  game  systems", "COWDOY  LUC");
        yield return DamagePlayer(7);
        yield return dialogueManager.TypeText("Oh  nooo!  The  player  is  on  low  health", "COWDOY  LUC");
        yield return dialogueManager.TypeText("Let's  heal  the  player!", "COWDOY  LUC");
        yield return HealPlayer(20);
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

}
