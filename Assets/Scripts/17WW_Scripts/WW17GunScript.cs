using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW17GunScript : MonoBehaviour
{
    public GameObject loc;
    public Transform holster;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (loc.GetComponent<WWPowerSliderScript>().powNum > 40 && loc.GetComponent<WWPowerSliderScript>().powNum < 60)
        {
            if (loc.GetComponent<WWPowerSliderScript>().sliderIsMoving == false)
            {
                Move();
            }
        }
    }

    private void Move()
    {
        for (int i = 0; i < 5; i++)
        {
            transform.position = Vector3.Lerp(transform.position, holster.transform.position, 0.2f);
        }
    }
}
