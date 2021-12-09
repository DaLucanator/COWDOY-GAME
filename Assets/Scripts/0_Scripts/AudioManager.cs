using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AuGameAttack;
    public AudioSource AuGameFail;
    public AudioSource AuGameHeal;
    public AudioSource AuGameMicroLose;
    public AudioSource AuGameMicroWin;
    public AudioSource AuGameShoot;
    public AudioSource AuGameShootHit;
    public AudioSource AuMenuAccept;
    public AudioSource AuMenuBack;
    public AudioSource AuMenuText;

    public void PlayAuGameAttack()
    {
        AuGameAttack.Play ();
    }
    public void PlayAuGameFail()
    {
        AuGameFail.Play ();
    }
    public void PlayAuGameHeal()
    {
        AuGameHeal.Play ();
    }
    public void PlayAuGameMicroLose()
    {
        AuGameMicroLose.Play ();
    }
    public void PlayAuGameMicroWin()
    {
        AuGameMicroWin.Play ();
    }
    public void PlayAuGameShoot()
    {
        AuGameShoot.Play ();
    }
    public void PlayAuGameShootHit()
    {
        AuGameShootHit.Play ();
    }
    public void PlayAuMenuAccept()
    {
        AuMenuAccept.Play ();
    }
    public void PlayAuMenuBack()
    {
        AuMenuBack.Play ();
    }
    public void PlayAuMenuText()
    {
        AuMenuText.Play ();
    }
}
