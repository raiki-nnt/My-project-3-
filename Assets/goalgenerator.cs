using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalgenerator : MonoBehaviour
{
    public List<Transform> goalSpawnPoints; // Inspectorで設定する
    public List<float> goalSpawny;
    private Transform selectedSpawnPoint;
    private UIController uiController;

    private Sound sound;
    private Sound sound1;

    // Start is called before the first frame update
    void Start()
    {
        goalSpawny =new List<float> {1.9f,-0.7f,-3.2f};
        uiController = GameObject.Find("score").GetComponent<UIController>();
        sound = this.GetComponent<Sound>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag=="friend")
        {
            int ynumber = Random.Range(0,3);
            float goalSpawnx = Random.Range(-7.9f,7.54f);
            this.transform.position=new Vector2(goalSpawnx,goalSpawny[ynumber]);
            uiController.OnGoalReached(100);
            sound.PlaySound(sound.sound);
            
        }   
    }

}
