using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW21TrainBrain : MonoBehaviour
{
    public AudioManager audioManager;

    public GameObject thePlayerThemself;
    public GameObject moveto;
    public GameObject spinny;
    public float randx;
    public float randy;
    public float waid;
    public int stepCount;
    public int maxStep;
    public bool aiCheck;
    public bool takeStep = true;
    public bool canWin;
    public bool ended;
    // Start is called before the first frame update
    void Start()
    {
        takeStep = true;
    }

    // Update is called once per frame
    void Update()
    {
        randx = spinny.transform.position.x;
        randy = spinny.transform.position.y;
        this.transform.position = new Vector3(randx, randy, -1.72f);
        if (aiCheck)
        {
            if (stepCount < maxStep)
            {
                if (takeStep)
                {
                    takeStep = false;
                    StartCoroutine(StepTime());

                }
            }
            else
            {
                if (!ended)
                {
                    ended = true;
                    audioManager.PlayAuGameFail();
                    Debug.Log("Lose");
                    GameController.current.ReturnToMain(false);
                }
            }
        }
        if (!aiCheck)
        {
            if (stepCount < maxStep)
            {
                if (Input.anyKeyDown)
                {
                    audioManager.PlayAuMenuText();
                    stepCount++;

                    thePlayerThemself.transform.position = Vector3.Lerp(thePlayerThemself.transform.position, moveto.transform.position, 0.02f);
                }
            }
            else
            {
                if (!ended)
                {
                    ended = true;
                    audioManager.PlayAuGameShootHit();
                    Debug.Log("Win!");
                    GameController.current.ReturnToMain(true);
                }
            }
        }
    }

    public IEnumerator StepTime()
    {
        stepCount++;
        thePlayerThemself.transform.position = Vector3.Lerp(thePlayerThemself.transform.position, moveto.transform.position, 0.08f);
        if (canWin)
        {
            waid = (Random.Range(1f, 100f) * 0.01f);
            yield return new WaitForSeconds(waid);
        }
        else
        {
            waid = (Random.Range(60f, 200f) * 0.01f);

            yield return new WaitForSeconds(waid);
        }


        takeStep = true;

    }


}
