using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDancePoseScript : MonoBehaviour
{
    public Material poseLeft;
    public Material poseUp;
    public Material poseRight;
    public Material poseDown;
    public int positionChoice;
    // Start is called before the first frame update
    void Start()
    {
        positionChoice = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (positionChoice == 1)
        {
            this.GetComponent<Renderer>().material = poseLeft;
        }
        else if (positionChoice == 2)
        {
            this.GetComponent<Renderer>().material = poseUp;

        }
        else if (positionChoice == 3)
        {
            this.GetComponent<Renderer>().material = poseRight;

        }
        else
        {
            this.GetComponent<Renderer>().material = poseDown;

        }
    }
}
