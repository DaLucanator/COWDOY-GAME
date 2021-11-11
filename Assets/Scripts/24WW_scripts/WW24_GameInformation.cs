using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW24_GameInformation : MonoBehaviour
{
    public int collected;
    public int bison;
    public bool won;
    // Start is called before the first frame update
    void Start()
    {
        bison = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!won && collected == bison)
        {
            won = true;
            Win();
        }
    }

    public void upCollected()
    {
        collected += 1;
    }

    void Win()
    {
        GameController.current.ReturnToMain(true);
    }
}
