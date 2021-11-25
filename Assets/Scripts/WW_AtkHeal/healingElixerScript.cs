using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingElixerScript : MonoBehaviour
{
    public Transform topLeft;
    public Transform botRight;
    public int healCount;
    public int healAmount;
    public bool cantCount;
    // Start is called before the first frame update
    void Start()
    {
        healCount = 1;
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (!cantCount && Input.anyKeyDown)
        {
            healCount++;
            transform.position = new Vector3(Random.Range(topLeft.position.x, botRight.position.x), Random.Range(topLeft.position.y, botRight.position.y), transform.position.z);
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5f);
        cantCount = true;
        if (healCount < 35)
        {
            healAmount = 1;
        }
        else if (healCount < 55)
        {
            healAmount = 2;
        }
        else if (healAmount < 80)
        {
            healAmount = 3;
        }
        else
        {
            healAmount = 4;
        }
    }
}
