using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitcheck : MonoBehaviour
{
    private List<GameObject> objectsInArea = new List<GameObject>();
    private GameObject hitenemy;
    //public bool Area = false;
    public KeyCode keycode;
    private GameObject leftGun; 
    private GameObject rightGun; 
    private Animator leftgunAnimator;
    private Animator rightgunAnimator;
    private UIController uiController;
    private SpriteRenderer spriteRenderer; 
    public int damegeAmount = 1;
    public AudioClip Sound;
    private Sound leftsound;
    private Sound rightsound;
    
    


    // Start is called before the first frame update
    void Start()
    {
        leftGun = GameObject.Find("leftGun");
        rightGun = GameObject.Find("rightGun");

        leftgunAnimator = leftGun.GetComponent<Animator>();
        rightgunAnimator = rightGun.GetComponent<Animator>();
        uiController = GameObject.Find("score").GetComponent<UIController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        leftsound = leftGun.GetComponent<Sound>();
        rightsound = rightGun.GetComponent<Sound>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keycode))
        {
            if(this.transform.position.x<0)
            {
                leftgunAnimator.SetTrigger("shot");
                leftsound.PlaySound(Sound);
            }
            else if(this.transform.position.x>=0)
            {
                rightgunAnimator.SetTrigger("shot");
                rightsound.PlaySound(Sound);
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        //objectsInArea.Add(other.gameOvject);
        if(other.gameObject.tag=="enemy1")
        {
            hitenemy = other.gameObject;
            
        }
        //Debug.Log("ok");
                 
    } 
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag=="enemy1")
        {
            spriteRenderer.color =new Color(1f, 0f, 0.09019608f);
        }

        if(Input.GetKeyDown(keycode))
        {

            if(other.gameObject.tag=="enemy1")
            {
                enemycontroller enemyhealth = other.gameObject.GetComponent<enemycontroller>();
                other.gameObject.GetComponent<enemycontroller>().TakeDamageAndCheckAnimation(damegeAmount);
                if(enemyhealth.health <= 0)
                {
                    enemycontroller enemypoint = other.gameObject.GetComponent<enemycontroller>();
                    uiController.OnEnemyDeath(enemypoint.point);
                }
            }
            
            //hitenemy = null;/
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        spriteRenderer.color=new Color(0.3607843f, 0.3803922f, 1.0f);
    }
        
}
