using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDancePointers : MonoBehaviour
{
    public GameObject bustaMove;
    public Material poseLeft;
    public Material poseUp;
    public Material poseRight;
    public Material poseDown;
    public int positionChoice;
    public bool Chungus; //Is Object Visable?
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        positionChoice = bustaMove.GetComponent<LineDancePoseScript>().positionChoice;
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
        if (!Chungus && Input.anyKeyDown)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
