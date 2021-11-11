using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW10SnakeBrain : MonoBehaviour
{
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
        if (other.tag == "Player")
        {
            Win();
        }
    }

    void Win()
    {
        GameController.current.ReturnToMain(true);
    }
}
