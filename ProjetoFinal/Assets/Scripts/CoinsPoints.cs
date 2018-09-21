using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CoinsPoints : MonoBehaviour {

    public static int points;
    public static int pointsLife;
    public static int lifeBoss;
    public Text txtPoints;
    public Text txtPointsLife;
    public Text txtReset;

    private GameObject gameOver;
    private GameObject youWin;

    // Use this for initialization
    void Start()
    {
        points = 0;
        pointsLife = 3;
        lifeBoss = 4;
        gameOver = GameObject.Find("GameOver");
        youWin = GameObject.Find("YouWin");
    }

    // Update is called once per frame
    void Update()
    {
        txtPoints.text = points.ToString();
        txtPointsLife.text = pointsLife.ToString();

        //finalizar jogo
        if (pointsLife == 0)
        {
            gameOver.GetComponent<SpriteRenderer>().enabled = true;
            txtReset.text = "Tecle R para reiniciar!";
            if (Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        if (keyCode == KeyCode.R)
                        {
                            SceneManager.LoadScene("GameScene");
                        }

                    }
                }
            }
        }

        if (lifeBoss == 0)
        {
            youWin.GetComponent<SpriteRenderer>().enabled = true;
            txtReset.text = "Tecle R para reiniciar!";
            if (Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        if (keyCode == KeyCode.R)
                        {
                            SceneManager.LoadScene("GameScene");
                        }

                    }
                }
            }
        }

    }
}
