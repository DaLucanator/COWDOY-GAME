using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusGod : MonoBehaviour
{
    public GameObject cactusLeft;
    public GameObject cactusMid;
    public GameObject cactusRight;
    public Material cac2sSkin;
    public int scaryBanditPosition;
    // Start is called before the first frame update
    void Start()
    {
        scaryBanditPosition = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (scaryBanditPosition == 1)
        {
            cactusLeft.GetComponent<Renderer>().material = cac2sSkin;
        }
        else if (scaryBanditPosition == 2)
        {
            cactusLeft.GetComponent<Renderer>().material = cac2sSkin;
        }
        else
        {
            cactusLeft.GetComponent<Renderer>().material = cac2sSkin;
        }
    }
}
