using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class friendcontller : MonoBehaviour
{
    public float Speed ;
    public int health ;
    private float moveSpeed;
    private float climbSpeed;
    private bool isClimibing = false;
    private float GravityScale;
    private Vector2 right = Vector2.right;
    private Vector2 left = Vector2.left;
    private Vector2 up = Vector2.up;
    private Vector2 down = Vector2.down;
    private Vector2 moveVector;
    private Vector2 direction;
    private Vector2 diresave;
    private GameObject goal;
    private SpriteRenderer spriteRenderer;

    private Animator animator;
    private Sound sound;
    private Sound sound1;
    private bool isInvincible = false;
    private float invincibilityDuration = 3f;
    private float invincibilityTimer = 0f;



    // Start is called before the first frame update
    void Start()
    {
        this.goal = GameObject.Find("goal");
        climbSpeed = Speed-1;
        moveSpeed = Speed;
        direction=left;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        sound = this.GetComponent<Sound>();
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == left)
        {
            FlipImageX(true);
        }
        if(direction == right)
        {
            FlipImageX(false);
        }
        if(!isClimibing)//動く
        {
            moveVector =(this.direction).normalized * moveSpeed * Time.deltaTime;
            transform.Translate(moveVector);
        }
        if (this.health < 1)
        {
            GameObject.Find("score").GetComponent<UIController> ().GameOver ();
            Destroy (gameObject);
        }
        // もし無敵状態なら、タイマーを更新する
        invincibilityTimer += Time.deltaTime;

        // 3秒経過したら無敵を解除
        if (invincibilityTimer >= invincibilityDuration)
        {
            isInvincible = false;
            invincibilityTimer = 0f;
        }
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
        if(other.gameObject.tag == "ladder")//梯子での動き
        {
            diresave=direction;
            isClimibing = true;//左右の動きを止める
            Vector2 newPosition = transform.position;//中心へ
            newPosition.x = other.transform.position.x;
            transform.position = newPosition;
            if(Math.Abs(this.transform.position.y - goal.transform.position.y) > 1 && this.transform.position.y < goal.transform.position.y)
            {
                direction=this.up;
                animator.SetBool ("climb", true);
            }
            else if(Math.Abs(this.transform.position.y - goal.transform.position.y) > 1 && this.transform.position.y > other.transform.position.y && this.transform.position.y > goal.transform.position.y)
            {
                direction=this.down;
                animator.SetBool ("climb", true);   
            }
        }
        if(other.gameObject.tag == "enemy1" && !isInvincible)
        {
            animator.SetTrigger("hurt");
            health-=1;
            sound.PlaySound(sound.sound);


        }
        // if(other.gameObject.tag == "goal")
        // {
        //     Destroy(other.gameObject);
        //     goalgenerator goalgene = GetComponent<goalgenerator>();
        //     goalgene.InstantiateNewGoal();
        // }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag =="ladder")//梯子での動き
        {
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
            if (hit.collider != null && hit.collider.gameObject.tag == "road" && direction== down)
            {
                // 床に当たっている場合は下に移動しない
                direction = diresave;
            }
            moveVector =(this.direction).normalized * climbSpeed * Time.deltaTime;
            transform.Translate(moveVector);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag =="ladder")//梯子での動き
        {
            this.animator.SetBool ("climb", false);
            if(direction==up)//登った後の微妙な動き
            {
                
                direction=diresave;
                moveVector =(this.direction).normalized * 35 * Time.deltaTime;
                transform.Translate(moveVector);
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.05f);
            }
            

            isClimibing = false;
        }
    }
    void FlipImageX(bool flipX)
    {
        spriteRenderer.flipX = flipX;
    }
}
