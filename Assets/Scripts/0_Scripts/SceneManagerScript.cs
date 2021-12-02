using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public List<string> gamesToLoad;
    [SerializeField]
    [ReadOnly]
    List<string> gamesToNotLoad;

    [ReadOnly]
    public string gameToLoad;


    public void pickMicrogame()
    {
        if(gamesToLoad.Count == 0)
        {
            gamesToLoad.AddRange(gamesToNotLoad);
            gamesToNotLoad.Clear();
        }
        gameToLoad = gamesToLoad[Random.Range(0, gamesToLoad.Count-1)];
        gamesToNotLoad.Add(gameToLoad);
        gamesToLoad.Remove(gameToLoad);
    }

    public void loadMicroGame()
    {
        SceneManager.LoadScene(gameToLoad);
    }
}
