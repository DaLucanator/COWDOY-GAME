using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWMG02PowerSliderScript : MonoBehaviour
{
    public GameObject icon;
    public GameObject powerPlace;
    public Transform topLoc;
    public Transform botLoc;
    public Vector3 iconPlace;
    public Vector3 botSpot;
    public Vector3 topSpot;
    public float distBetween;
    public int powNum;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        botSpot = new Vector3(botLoc.position.x, botLoc.position.y, botLoc.position.z);
        topSpot = new Vector3(topLoc.position.x, topLoc.position.y, topLoc.position.y);

        distBetween = (powNum)/100f;

        icon.transform.position = Vector3.Lerp(botSpot, topSpot, distBetween);
    }
}
