using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingElixerScript : MonoBehaviour
{
    private int healCount;
    [SerializeField]
    private int healAmount1, healAmount2, healAmount3, healAmount4;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            healCount++;
            transform.Rotate(0, 0, 1);
            if (healCount < 35)
            {
                GameController.current.healAmount = healAmount1;
            }
            else if (healCount < 55)
            {
                GameController.current.healAmount = healAmount2;
            }
            else if (healCount < 80)
            {
                GameController.current.healAmount = healAmount3;
            }
            else
            {
                GameController.current.healAmount = healAmount4;
            }
        }
    }
}
