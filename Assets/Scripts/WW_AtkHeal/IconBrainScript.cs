using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconBrainScript : MonoBehaviour
{
    public Transform leftEnd;
    public Transform rightEnd;
    public int damageScale;
    public float speed;
    public float distBetween;
    public int powNum;
    public bool goingUp;
    public bool sliderIsMoving;
    // Start is called before the first frame update
    void Start()
    {
        sliderIsMoving = true;
        StartCoroutine(timing());

    }

    // Update is called once per frame
    void Update()
    {
        distBetween = (powNum) / 100f;
        transform.position = Vector3.Lerp(leftEnd.position, rightEnd.position, distBetween);

        if (powNum > 99)
        {
            goingUp = false;
        }
        else if (powNum < 1)
        {
            goingUp = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sliderIsMoving = false;
            DamCheck();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(timing());
        }
    }

    IEnumerator timing()
    {
        while (sliderIsMoving)
        {


            if (goingUp)
            {
                powNum++;
            }
            else
            {
                powNum--;
            }
            yield return new WaitForSeconds(speed);
        }
    }

    public void DamCheck()
    {
        /*if Dam == 1 {Miss/Low Damage}
         if Dam == 2 {Mid/Normal Damage}
        if Dam == 3 {High/Crit Damage}*/

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "damageLow")
        {
            damageScale = 1;
        }
        if (other.tag == "damageMed")
        {
            damageScale = 2;
        }
        if (other.tag == "damageHigh")
        {
            damageScale = 3;
        }
    }

    IEnumerator endTime()
    {
        //whatever graphic goes here at end
        yield return new WaitForSeconds(2f);

    }
}
