using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW11_CactAss : MonoBehaviour
{
    public GameObject badBrain;
    public int thisCactus;
    public bool hover;
    public bool click;
    public Material m1;
    public Material m2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.thisCactus == badBrain.GetComponent<WW11_badBrain>().choose)
        {
            this.GetComponent<Renderer>().material = m2;
        }
        else
        {
            this.GetComponent<Renderer>().material = m1;

        }


        if (Input.GetMouseButtonDown(0))
        {
            click = true;
        }
        if (hover && this.thisCactus == badBrain.GetComponent<WW11_badBrain>().choose && Input.GetMouseButtonDown(0))
        {
            Win();
        }

        
        //if timer runout, Lose();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            hover = true;
        }
    }

    public void Win()
    {
        Debug.Log("Win");
        GameController.current.ReturnToMain(true);
    }

    public void Lose()
    {
        Debug.Log("Lose");
    }
}
