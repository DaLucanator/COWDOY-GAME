using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingElixerScript : MonoBehaviour
{
    [ReadOnly]
    [SerializeField]
    private int healCount;
    [SerializeField]
    private int healAmount1, healAmount2, healAmount3;
    [SerializeField]
    private float movespeed;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            healCount++;
            transform.Rotate(0, 0, movespeed);
            if (healCount > 90)
            {
                GameController.current.healAmount = healAmount1;
            }
            else if (healCount < 90)
            {
                GameController.current.healAmount = healAmount2;
            }
            else if (healCount < 180)
            {
                GameController.current.healAmount = healAmount3;
            }
        }
    }
}
