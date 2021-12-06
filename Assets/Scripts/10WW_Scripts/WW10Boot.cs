using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW10Boot : MonoBehaviour
{
    public GameObject Snape;
    public GameObject moveto;
    public Vector3 bootPosition;
    public float randx;
    public float randy;
    public int shakeCount;
    public int maxShake;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bootPosition = this.transform.position;
        if (shakeCount < maxShake)
        {
            if (Input.anyKeyDown)
            {
                shakeCount++;
                randx = Random.Range(0.25f, 0.75f);
                randy = Random.Range(1.75f, 2.25f);
                this.transform.position = new Vector3(randx, randy, 1);
                Snape.transform.position = Vector3.Lerp(Snape.transform.position, moveto.transform.position, 0.02f);
            }
        }
        else
        {
            Snape.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
