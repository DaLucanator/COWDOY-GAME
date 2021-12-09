using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconBrainScript : MonoBehaviour
{
    //woody wrote (most) this code

    public Transform leftEnd;
    public Transform rightEnd;
    public float speed;
    public float distBetween;
    public int powNum;
    public bool goingUp;
    public bool sliderIsMoving;

    [SerializeField]
    private int damageAmount1, damageAmount2, damageAmount3;

    private string dialogueString;

    private DialogueManager dialogueManager;
    private Timer timer;

    void Start()
    {
        dialogueManager = GameController.current.GetComponent<DialogueManager>();
        timer = GameController.current.GetComponent<Timer>();
        sliderIsMoving = true;
        StartCoroutine(timing());
    }

    void Update()
    {
        distBetween = (powNum) / 100f;
        transform.position = Vector3.Lerp(leftEnd.position, rightEnd.position, distBetween);

        if (powNum > 99)
        {
            goingUp = false;
        }
        else if (powNum < 1)
        {
            goingUp = true;
        }

        if (Input.anyKeyDown)
        {
            {
                if (sliderIsMoving)
                {
                    sliderIsMoving = false;
                    StartCoroutine(EndLevel());
                }
            }
        }

    }

    IEnumerator timing()
    {
        while (sliderIsMoving)
        {
            if (goingUp)
            {
                powNum++;
            }
            else
            {
                powNum--;
            }
            yield return new WaitForSeconds(speed);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "damageLow")
        {
            GameController.current.damageAmount = damageAmount1;
            dialogueString = "It's a miss!";
        }
        if (other.tag == "damageMed")
        {
            GameController.current.damageAmount = damageAmount2;
            dialogueString = "It's a hit!";
        }
        if (other.tag == "damageHigh")
        {
            GameController.current.damageAmount = damageAmount3;
            dialogueString = "A critical Hit";
        }
    }

    private IEnumerator EndLevel()
    {
        timer.TimerStop();
        yield return dialogueManager.TypeText("The Cowboy fired some shots.");
        yield return dialogueManager.TypeText(dialogueString);
        GameController.current.ReturnToMainAttackOrHeal(true);
    }
}
