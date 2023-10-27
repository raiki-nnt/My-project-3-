using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private GameObject gameOverText;
    private int point = 0;
    private GameObject point1;
    private GameObject point2;

    private GameObject score;
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameOverText  = GameObject.Find ("GameOver");
        this.score = GameObject.Find ("score");  
        //this.point1=GameObject.Find("goalgenerator"); 

        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void GameOver()
    {
        
        //this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
        PlayerPrefs.SetInt("Score",point);
        
        PlayerPrefs.Save();
        SceneManager.LoadScene("End");
    }
    public void OnEnemyDeath(int point1)
    {
        if (this.isGameOver == false)
        {
            // 引数として渡されたポイントを加算
            point += point1;
            this.score.GetComponent<Text> ().text = "score:  " + point.ToString ();
        }
    }
    public void OnGoalReached(int point2)
    {
        if (this.isGameOver == false)
        {
            // 引数として渡されたポイントを加算
            point += point2;
            this.score.GetComponent<Text> ().text = "score:  " + point.ToString ();
        }
    }

}   
