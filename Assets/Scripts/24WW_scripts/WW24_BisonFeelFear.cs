using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW24_BisonFeelFear : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject stats;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "WW24Mouse")
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, -speed);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (other.tag == "WW24Pen")
        {
            audioManager.PlayAuMenuAccept();
            Destroy(this.gameObject);
            stats.GetComponent<WW24_GameInformation>().upCollected();
        }
    }

}

