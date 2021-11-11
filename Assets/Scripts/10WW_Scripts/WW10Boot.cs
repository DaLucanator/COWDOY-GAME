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
                randx = Random.Range(-0.21f, 0.31f);
                randy = Random.Range(1.98f, 1.53f);
                this.transform.position = new Vector3(randx, randy, -1.72f);
                Snape.transform.position = Vector3.Lerp(Snape.transform.position, moveto.transform.position, 0.02f);
            }
        }
        else
        {
            Snape.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
