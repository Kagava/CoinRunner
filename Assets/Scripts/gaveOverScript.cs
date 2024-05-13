using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gaveOverScript : MonoBehaviour
{

    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject leftRightPanel;
    public static int numberCoins = 0;
    public Text coins;
    public Text score;
    public static bool isGameStart = false;
    public GameObject tapText;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        numberCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            leftRightPanel.SetActive(false);
            score.text = numberCoins.ToString();
            isGameStart = false;
        }
        coins.text = "Coins " + numberCoins;
        if(swipeManager.tap)
        {
            isGameStart = true;
            Destroy(tapText);
            
        }
    }
}
