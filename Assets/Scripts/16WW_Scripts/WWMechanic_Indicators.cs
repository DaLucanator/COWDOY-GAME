using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWMechanic_Indicators : MonoBehaviour
{
    public GameObject Indicator1;
    public GameObject Indicator2;
    public GameObject Indicator3;
    public GameObject Indicator4;
    public float countdown;
    public int currentIndicator;
    public int clickCount;
    public int clickMax;
    public bool nextCheck;
    public bool timerCheck;
    public bool inputCheck;
    public bool won;
    public bool working;
    // Start is called before the first frame update
    void Start()
    {
        currentIndicator = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (clickCount > clickMax && !won)
        {
            won = true;
            Win();
        }
        if (clickCount == clickMax || clickCount > clickMax)
        {
            Indicator1.GetComponent<MeshRenderer>().enabled = false;
            Indicator2.GetComponent<MeshRenderer>().enabled = false;
            Indicator3.GetComponent<MeshRenderer>().enabled = false;
            Indicator4.GetComponent<MeshRenderer>().enabled = true;
            if (nextCheck)
            {
                timerCheck = true;
                nextCheck = false;

                StartCoroutine(NextThingCount());
            }
            if (Input.anyKeyDown)
            {
                inputCheck = true;
                //   Lose();
            }
        }
        else if (currentIndicator == 1)
        {
            Indicator1.GetComponent<MeshRenderer>().enabled = true;
            Indicator2.GetComponent<MeshRenderer>().enabled = false;
            Indicator3.GetComponent<MeshRenderer>().enabled = false;
            Indicator4.GetComponent<MeshRenderer>().enabled = false;
            if (Input.anyKeyDown)
            {
                currentIndicator = Random.Range(2, 4);
                if (currentIndicator == 3 || currentIndicator == 4)
                {
                    nextCheck = true;
                }
                clickCount++;
            }
        }
        else if (currentIndicator == 2)
        {
            Indicator1.GetComponent<MeshRenderer>().enabled = false;
            Indicator2.GetComponent<MeshRenderer>().enabled = true;
            Indicator3.GetComponent<MeshRenderer>().enabled = false;
            Indicator4.GetComponent<MeshRenderer>().enabled = false;
            if (Input.anyKeyDown)
            {
                currentIndicator = Random.Range(2, 4);
                if (currentIndicator == 3 || currentIndicator == 4)
                {
                    nextCheck = true;
                }
                clickCount++;
            }
        }
        else if (currentIndicator == 3)
        {
            Indicator1.GetComponent<MeshRenderer>().enabled = false;
            Indicator2.GetComponent<MeshRenderer>().enabled = false;
            Indicator3.GetComponent<MeshRenderer>().enabled = true;
            Indicator4.GetComponent<MeshRenderer>().enabled = false;
            if (nextCheck)
            {
                timerCheck = true;
                nextCheck = false;

                StartCoroutine(NextThingCount());
            }
            if (Input.anyKeyDown)
            {
                inputCheck = true;
                Lose();
            }
        }

    }

    private IEnumerator NextThingCount()
    {
        yield return new WaitForSeconds(countdown);
        if (!inputCheck)
        {
            if (clickCount != clickMax)
            {
                currentIndicator = Random.Range(2, 4);
                if (currentIndicator == 3 || currentIndicator == 4)
                {
                    nextCheck = true;
                }
            }

            clickCount++;
        }
    }

    private void Win()
    {
        Debug.Log("Win");
    }

    private void Lose()
    {
        Debug.Log("Lose");
    }
}
