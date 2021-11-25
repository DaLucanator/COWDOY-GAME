using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW10SnakeBrain : MonoBehaviour
{
    public GameObject train;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (train.GetComponent<WW21TrainBrain>().aiCheck)
        {
            if (other.tag == "Player")
            {
                Lose();
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                Win();
            }
        }
    }

    void Win()
    {
        GameController.current.ReturnToMain(true);
    }

    void Lose()
    {
        GameController.current.ReturnToMain(false);
    }
}
