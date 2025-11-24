using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool gameOver; //-> Not used but could be used to say that the game is over for all the other scripts, checking with the instnace

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        FindObjectOfType<platformSpawner>().StarSpawning();
        //GameObject.Find("PlatformSpawner").GetComponent<platformSpawner>().StarSpawning(); -> way to find an object in the game
    }
    public void GameOver()
    {
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        gameOver = false;
    }
}
