using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sound : MonoBehaviour
{
    public AudioClip sound;
    public AudioClip sound1;
    private AudioSource audioSource;
    
    

    // 任意の効果音を再生するメソッド
        void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        
        

    }
    public void PlaySound(AudioClip soundClip)
    {
        audioSource.clip = sound;
        this.audioSource.Play();
    }
    public void PlaySound1(AudioClip soundClip)
    {
        audioSource.clip = sound1;
        this.audioSource.Play();
    }

    
}
