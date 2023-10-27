using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
   // private float nextSpawnTime;
    //public float spawnInterval = 0.005f;
    public float moveSpeed;
    public int health ;
    private Vector2 right = Vector2.right;
    private Vector2 left = Vector2.left;
    private Vector2 up = Vector2.up;
    private Vector2 down = Vector2.down;
    private Vector2 direction;
    private SpriteRenderer spriteRenderer;
    public int point;
    private Animator animator;
    private Sound sound;
    private Sound sound1;
    private float handi;
    //private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        handi = PlayerPrefs.GetFloat("handi", 0);
        direction=left;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        sound = this.GetComponent<Sound>();
        
        if(handi>=1)
        {
            if(point==10)
            {
                health=health+1;
            }
            else if(point==20)
            {
                health=health+1;
            }
            else if(point==30)
            {
                moveSpeed=moveSpeed+1;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == left)
        {
            FlipImageX(false);
        }
        if(direction == right)
        {
            FlipImageX(true);
        }
        Vector2 moveVector =(this.direction).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(-moveVector);
    }
        private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "wall")//壁に当たった
        {
            if(direction == left)
            {
                direction = this.right;
            }
            else if(direction == right)
            {
                direction=this.left;
            }
        }
        if(other.gameObject.tag == "friend")
        {
             animator.SetTrigger("attack");
        }
    }
     void FlipImageX(bool flipX)//画像の向き
    {
        spriteRenderer.flipX = flipX;
    }
    public void TakeDamageAndCheckAnimation(int damage)
     {
        health -= damage;

        if (health <= 0)
        {
            moveSpeed=0;
            StartCoroutine(DestroyDelayed(0.7f));
            animator.SetTrigger("down");
            sound.PlaySound1(sound.sound1);
        }
        else
        {
            
            // ヘルスが減った時にアニメーションを変更する処理
            animator.SetTrigger("hit");
            sound.PlaySound(sound.sound);
        }
    }
    IEnumerator DestroyDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
