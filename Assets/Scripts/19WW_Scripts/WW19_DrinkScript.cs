using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW19_DrinkScript : MonoBehaviour
{
    public GameObject glass;
    public AudioManager audioManager;
    //public AudioSource smash;
    //public AudioClip smashSound;
    //public AudioClip winSound;
    public float delayTime;
    public float moveSpeed;
    public bool overlap;
    public bool move;

    // Start is called before the first frame update
    void Start()
    {
        //smash = this.GetComponent<AudioSource>();
        delayTime = Random.Range(10, 30);
        delayTime = delayTime / 10;
        moveSpeed = (Random.Range(80, 180)) * 0.1f;
        StartCoroutine(quickMafs());
    }

    // Update is called once per frame
    void Update()
    {
        if (overlap)
        {
            if (Input.anyKeyDown)
            {
                move = false;
                audioManager.PlayAuMenuAccept();
                Win();
            }
        }
        if (move)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            overlap = true;
        }
        if (other.tag == "BreaksGlass")
        {
            audioManager.PlayAuGameFail();
            Lose();
            //Play smashing glass noise
            //lose()
        }
    }

    void OnTriggerExit(Collider other)
    {
        overlap = false;
    }

    void Win()
    {
        Debug.Log("Win");
        
        move = false;

        GameController.current.ReturnToMain(true);
        //add win event
    }

    void Lose()
    {
        Debug.Log("Lose");

        move = false;

        //GameController.current.ReturnToMain(false);
        //Add loss.jpg
    }

    IEnumerator quickMafs()
    {
        yield return new WaitForSeconds(delayTime);
        audioManager.PlayAuGameShoot();
        move = true;
    }
}
