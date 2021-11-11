using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW24_GameInformation : MonoBehaviour
{
    public int collected;
    public int bison;
    // Start is called before the first frame update
    void Start()
    {
        bison = 6;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void upCollected(){
        collected += 1; 
    }

    
}
