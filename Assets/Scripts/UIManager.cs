using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject zigZagPanel;
    public GameObject GameOverPanel;
    public GameObject TapText;
    public Text score;
    public Text HighScore1;
    public Text HighScore2;

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
        HighScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }


    public void GameStart()
    {
        //TapText.SetActive(false);
        TapText.GetComponent<Animator>().Play("TextDown");
        zigZagPanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        HighScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        GameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
