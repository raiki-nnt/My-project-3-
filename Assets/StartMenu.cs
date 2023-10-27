using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Text titleText;
    public Button startButton;
    public float handi;

    void Start()
    {
        // ボタンが押されたときの処理を追加
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        PlayerPrefs.SetFloat("handi",handi);
        
        PlayerPrefs.Save();
        // ゲームシーンに遷移
        SceneManager.LoadScene("SampleScene");
    }
}
