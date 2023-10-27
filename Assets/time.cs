using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class time : MonoBehaviour
{
    public float countdownTime = 300f; // タイマーの初期時間
    // Start is called before the first frame update
    private int currentTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime; // 経過時間を引く
            currentTime = Mathf.RoundToInt(countdownTime);
            this.GetComponent<Text> ().text = "Tiem: " + currentTime.ToString ();
        }
        else
        {
            // タイマーがゼロになったときの処理
            GameObject.Find("score").GetComponent<UIController> ().GameOver ();
        }
    }
}
