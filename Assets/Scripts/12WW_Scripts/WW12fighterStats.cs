using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW12fighterStats : MonoBehaviour
{
    public GameObject theOtherGuy;
    public int health;
    public int ID;
    public int stance;
    public float punchTimer;
    public bool hitting;
    public bool defending;
    public bool AIAttemptCheck;
    public bool ended;
    public Sprite Idle;
    public Sprite Attack;
    public Sprite Defend;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (stance == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = Idle;
        }
        else if (stance == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = Attack;
        }
        else if (stance == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = Defend;
        }
        if (!ended)
        {


            if (ID == 1)
            {

                if (!hitting && Input.GetKeyDown(KeyCode.A))
                {
                    AttemptHit();
                    StartCoroutine(PunchTime());
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    defending = true;
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    defending = false;
                }

                if (hitting)
                {
                    stance = 2;
                }
                else if (defending)
                {
                    stance = 3;
                }
                else if (!defending && !hitting)
                {
                    stance = 1;
                }
            }
            if (ID == 2 && !AIAttemptCheck)
            {
                StartCoroutine(AIAttack());
            }
        }
    }

    private void OnHit()
    {
        health--;
        if (health < 1)
        {
            if (ID == 1)
            {
                Lose();
            }
            else if (ID == 2 && !ended)
            {
                Win();
            }
        }
    }

    private void Win()
    {
        ended = true;
        Debug.Log("win");
        GameController.current.ReturnToMain(true);
    }

    private void Lose()
    {
        ended = true;
        Debug.Log("Lose");
        GameController.current.ReturnToMain(false);
    }

    private IEnumerator PunchTime()
    {
        hitting = true;
        //hitOther()
        yield return new WaitForSeconds(punchTimer);
        hitting = false;
    }

    public void AttemptHit()
    {
        if (theOtherGuy.GetComponent<WW12fighterStats>().stance != 3)
        {
            theOtherGuy.GetComponent<WW12fighterStats>().OnHit();
        }
        //Else play block sound maybe?
    }

    public IEnumerator AIAttack()
    {
        AIAttemptCheck = true;
        float waitTime = (Random.Range(40f, 180f)) * 0.01f;
        Debug.Log("Check");
        yield return new WaitForSeconds(waitTime);
        stance = 3;
        yield return new WaitForSeconds(punchTimer);
        stance = 2;
        AttemptHit();
        yield return new WaitForSeconds(punchTimer);
        stance = 1;
        AIAttemptCheck = false;
    }
}
