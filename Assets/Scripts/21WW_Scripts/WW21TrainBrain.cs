using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW21TrainBrain : MonoBehaviour
{
    public GameObject thePlayerThemself;
    public GameObject moveto;
    public GameObject spinny;
    public float randx;
    public float randy;
    public int stepCount;
    public int maxStep;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        randx = spinny.transform.position.x;
        randy = spinny.transform.position.y;
        this.transform.position = new Vector3(randx, randy, -1.72f);

        if (stepCount < maxStep)
        {
            if (Input.anyKeyDown)
            {
                stepCount++;


                thePlayerThemself.transform.position = Vector3.Lerp(thePlayerThemself.transform.position, moveto.transform.position, 0.02f);
            }
        }
        else
        {
            thePlayerThemself.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
