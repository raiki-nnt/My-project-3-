using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endUI : MonoBehaviour
{
    private Text scoreText;
    private int point;
    public Button ResetButton;
    private float handi;
    private float magnification = 1f;
    // Start is called before the first frame update
    void Start()
    {
        handi = PlayerPrefs.GetFloat("handi", 0);
        point = PlayerPrefs.GetInt("Score", 0);
        //  ボーナス
        if(handi==1)
        {
            magnification=1.2f;
        }
        else if(handi==2)
        {
            magnification=1.45f;
        }
        else if(handi==3)
        {
            magnification=2f;
        }

        float floatpoint =(float)point;
        floatpoint = floatpoint*magnification;
        point =(int)floatpoint;

        GameObject scoreObject = GameObject.Find("score");
        scoreText = scoreObject.GetComponent<Text>();
        scoreText.text = "score:  " + point.ToString() + " "+"(×"+ magnification.ToString() +")";
        ResetButton.onClick.AddListener(resetButton);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void resetButton()
    {
        // ゲームシーンに遷移
        SceneManager.LoadScene("Title");
    }
}
