using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zanki : MonoBehaviour
{
    public GameObject friend;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = friend.GetComponent<friendcontller>().health;
        this.GetComponent<Text>().text = "残機  　×" + health.ToString();
    }
}
