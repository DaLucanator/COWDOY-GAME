using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DB38TextScript : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject Answer1;
    public GameObject Answer2;
    public GameObject Answer3;
    public GameObject Answer4;
    public GameObject Answer5;

    public Transform Slot1;
    public Transform Slot2;
    public Transform Slot3;
    public Transform Slot4;
    public Transform Slot5;

    public GameObject Correct1;
    public GameObject Correct2;
    public GameObject Correct3;
    public GameObject Correct4;
    public GameObject Correct5;

    public bool Slot1Filled;
    public bool Slot2Filled;
    public bool Slot3Filled;
    public bool Slot4Filled;
    public bool Slot5Filled;

    public bool Failed;
    public void AnswerClicked(GameObject Selection)
    {
        // if Slot1Filled = false
        //  {
        //      transform to Slot1 | Slot1Filled = true

        //      if Selection != Correct1
        //          {
        //             Failed = true
        //          }
        //  }
        if (Slot1Filled == false)
        {
            print("Clicked an Answer");
            Selection.transform.position = Slot1.position;
            Slot1Filled = true;

            if (Selection != Correct1)
            {
                print("Incorrect Answer Input");
                Failed = true;
            }
        }

        // else if Slot2Filled = false
        //  {
        //      transform to Slot2 | Slot2Filled = true

        //      if Selection != Correct2
        //          {
        //             Failed = true
        //          }
        //  }
        else if (Slot2Filled == false)
        {
            print("Clicked an Answer");
            Selection.transform.position = Slot2.position;
            Slot2Filled = true;

            if (Selection != Correct2)
            {
                print("Incorrect Answer Input");
                Failed = true;
            }
        }

        // else if Slot3Filled = false
        //  {
        //      transform to Slot3 | Slot3Filled = true

        //      if Selection != Correct3
        //          {
        //             Failed = true
        //          }
        //  }
        else if (Slot3Filled == false)
        {
            print("Clicked an Answer");
            Selection.transform.position = Slot3.position;
            Slot3Filled = true;

            if (Selection != Correct3)
            {
                print("Incorrect Answer Input");
                Failed = true;
            }
        }

        // else if Slot4Filled = false
        //  {
        //      transform to Slot4 | Slot4Filled = true

        //      if Selection != Correct4
        //          {
        //             Failed = true
        //          }
        //  }
        else if (Slot4Filled == false)
        {
            print("Clicked an Answer");
            Selection.transform.position = Slot4.position;
            Slot4Filled = true;

            if (Selection != Correct4)
            {
                print("Incorrect Answer Input");
                Failed = true;
            }
        }

        // else if Slot5Filled = false
        //  {
        //      transform to Slot5 | Slot5Filled = true

        //      if Selection != Correct5
        //          {
        //             Failed = true
        //          }
        //  }
        else if (Slot5Filled == false)
        {
            print("Clicked an Answer");
            Selection.transform.position = Slot5.position;
            Slot5Filled = true;

            if (Selection != Correct5)
            {
                print("Incorrect Answer Input");
                Failed = true;
            }

            if (Failed == true)
            {
                print("Game Over...");
                GameController.current.ReturnToMain(false);
                //Go to Game Over State
            }
            else
            {
                print("You Win!");
                GameController.current.ReturnToMain(true);
                //Go to Win State
            }
        }
    }
}
