using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class enemygenerator : MonoBehaviour
{
    //enemy1
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;
    public GameObject enemy5Prefab;
    public GameObject friend; 
    private int enemynumber;
    private float nextSpawnTime;
    public float spawnInterval;
    private float enemySpawnx;
    public List<float> enemySpawny;
    public List<GameObject> enemytype;
    private Transform selectedSpawnPoint;
    private float friendx;
    private float handi;
    // Start is called before the first frame update
    void Start()
    {
        handi = PlayerPrefs.GetFloat("handi", 0);
        enemySpawny =new List<float> {1.9f,-0.7f,-3.2f,4f};　//y座標指定
        enemytype  =new List<GameObject> {enemy1Prefab,enemy2Prefab,enemy3Prefab,enemy4Prefab,enemy5Prefab};
        if(handi==2)
        {
            spawnInterval=spawnInterval-0.6f;
        }
        else if(handi==3)
        {
            spawnInterval=spawnInterval-1f;
        }
        nextSpawnTime = Time.time +spawnInterval; //初めのスポーン時間
        for (int i = 0 ; i < 3; i++)
        {
            int ynumber = UnityEngine.Random.Range(0,3);
            while (true)
            {
                float enemySpawnx = UnityEngine.Random.Range(-7.9f,7.54f);
                this.friend=GameObject.Find("friend");
                float friendx=friend.transform.position.x;
                if(Math.Abs(friendx-enemySpawnx)>=2.8f) break;

            }
            GameObject enemy =Instantiate (enemytype[0]);
            enemy.transform.position = new Vector2 (enemySpawnx,enemySpawny[ynumber]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //次の指定時間か
        if (Time.time >= nextSpawnTime)
        {
            int number = UnityEngine.Random.Range(0,100);
            if(number<=30)
            {
                enemynumber=0;
            }
            else if(number<55)
            {
                enemynumber=1;
            }
            else if(number<90)
            {
                enemynumber=2;
            }
            else if(number<95)
            {
                enemynumber=3;
            }
            else if(number<100)
            {
                enemynumber=4;
            }
            int ynumber = UnityEngine.Random.Range(0,3);
            if(enemynumber>2)
            {
                ynumber=3;
            }
            
            do
            {
                enemySpawnx = UnityEngine.Random.Range(-7.9f, 7.54f);
            } while (Mathf.Abs(friend.transform.position.x - enemySpawnx) < 4f);


            GameObject enemy =Instantiate (enemytype[enemynumber]);
            enemy.transform.position = new Vector2 (enemySpawnx,enemySpawny[ynumber]);
            nextSpawnTime = Time.time + spawnInterval;//次の時間の設定
        }
        
    }
}
