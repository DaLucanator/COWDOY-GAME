using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW11_CactAss : MonoBehaviour
{
    public GameObject badBrain;
    public int thisCactus;
    public bool hover;
    public bool click;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.thisCactus == badBrain.GetComponent<WW11_badBrain>().choose)
        {
            this.GetComponent<Animator>().enabled = true;
        }


        if (Input.GetMouseButtonDown(0))
        {
            click = true;
        }
        if (hover && this.thisCactus == badBrain.GetComponent<WW11_badBrain>().choose && Input.GetMouseButtonDown(0))
        {
            Win();
        }
        if (hover && this.thisCactus != badBrain.GetComponent<WW11_badBrain>().choose && Input.GetMouseButtonDown(0))
        {
            Lose();
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

    private void OnTriggerExit(Collider other)
    {
        hover = false;
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
