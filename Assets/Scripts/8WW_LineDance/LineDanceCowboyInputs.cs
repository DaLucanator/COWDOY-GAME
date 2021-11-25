using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDanceCowboyInputs : MonoBehaviour
{
    public GameObject bustaMove;
    public GameObject bustaMove1;
    public GameObject bustaMove2;
    public GameObject bustaMove3;
    public GameObject bustaMove4;
    public Material poseLeft;
    public Material poseUp;
    public Material poseRight;
    public Material poseDown;
    public Material idlePose;
    public int positionChoice;
    public int posInput;
    public int progression;
    public bool canDance;
    // Start is called before the first frame update
    void Start()
    {
        progression = 1;
        canDance = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (progression == 1)
        {
            bustaMove = bustaMove1;
        }
        else if (progression == 2)
        {
            bustaMove = bustaMove2;
        }
        else if (progression == 3)
        {
            bustaMove = bustaMove3;
        }
        else if (progression == 4)
        {
            bustaMove = bustaMove4;
        }
        if (canDance)
        {


            positionChoice = bustaMove.GetComponent<LineDancePoseScript>().positionChoice;
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                posInput = 1;
                this.GetComponent<Renderer>().material = bustaMove.GetComponent<LineDancePoseScript>().poseLeft;
                StartCoroutine(danceTime());
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                posInput = 2;
                this.GetComponent<Renderer>().material = bustaMove.GetComponent<LineDancePoseScript>().poseUp;

                StartCoroutine(danceTime());
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                posInput = 3;
                this.GetComponent<Renderer>().material = bustaMove.GetComponent<LineDancePoseScript>().poseRight;

                StartCoroutine(danceTime());
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {

                posInput = 4;
                this.GetComponent<Renderer>().material = bustaMove.GetComponent<LineDancePoseScript>().poseDown;

                StartCoroutine(danceTime());
            }
        }
    }

    public IEnumerator danceTime()
    {

        yield return new WaitForSeconds(0.7f);
        this.GetComponent<Renderer>().material = idlePose;
        if (posInput == positionChoice)
        {
            progression++;
            canDance = true;
            if (progression > 4)
            {
                Win();
            }
        }
        else
        {
            Lose();
        }

    }

    public void Win()
    {
        Debug.Log("Win");
        GameController.current.ReturnToMain(true);
    }

    public void Lose()
    {
        Debug.Log("Lose");
        GameController.current.ReturnToMain(false);
    }
}