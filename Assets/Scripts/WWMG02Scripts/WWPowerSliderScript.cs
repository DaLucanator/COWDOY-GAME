using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWPowerSliderScript : MonoBehaviour
{
    public GameObject icon;
    public GameObject powerPlace;
    public Transform topLoc;
    public Transform botLoc;
    public Vector3 iconPlace;
    public Vector3 botSpot;
    public Vector3 topSpot;
    public float distBetween;
    public float speed;
    public int powNum;
    public bool goingUp;
    public bool sliderIsMoving;
    void Start()
    {
        sliderIsMoving = true;
        StartCoroutine(timing());
    }

    // Update is called once per frame
    void Update()
    {
        botSpot = new Vector3(botLoc.position.x, botLoc.position.y, botLoc.position.z);
        topSpot = new Vector3(topLoc.position.x, topLoc.position.y, topLoc.position.y);

        distBetween = (powNum) / 100f;

        icon.transform.position = Vector3.Lerp(botSpot, topSpot, distBetween);

        if (powNum > 99)
        {
            goingUp = false;
        }
        else if (powNum < 1)
        {
            goingUp = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sliderIsMoving = false;

            if (powNum > 40 && powNum < 60)
            {
                Win();
            }
            else
            {
                Debug.Log("Lose");
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
            yield return new WaitForSeconds((speed) * 0.001f);
        }
    }

    void Win()
    {
        Debug.Log("Win");
        GameController.current.ReturnToMain(true);
    }
}
