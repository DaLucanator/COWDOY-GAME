using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicKeep : MonoBehaviour
{
    public AudioSource BGM;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeBGM(AudioClip music)
    {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}