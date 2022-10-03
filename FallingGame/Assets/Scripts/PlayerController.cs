using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float speed;
    public float checkRadius; // to make sure where is the circle
    public LayerMask platform;
    public GameObject groundCheck; // to get a point on the ground, vector
        
    
    float xVelocity;
    bool playerDead;

    public bool isOnGround;


    void Start()
    {
        //to get the component
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    
    void Update()
    {
        //check whether it is falling
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position,checkRadius,platform);

        anim.SetBool("isOnGround", isOnGround);

        Movement();
    }
    // here is where we can use dial to control, usually will be left right key on keyboard to control the player. 

    void Movement()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xVelocity*speed, rb.velocity.y);

        // the facing direction will change, so use transform
        //check if the x-velocity = 0 or not, otherwise, it will disappear
        //Question: how do I change this to dial, since now it can directly be controlled by the keyboard
        
        //animation exchange
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x)); //running anim

        if(xVelocity != 0)
        {
            transform.localScale = new Vector3(xVelocity,1,1);
        }
    }

    //check whether the user touched any spike
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("spike")){

            anim.SetTrigger("dead");
        }
    }
    
    //when the user touched the Fly Fan, it can jump a bit
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Fan")){
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
    }

    //when the anim goes to the last sec, the player dead
    public void PlayerDead(){
        playerDead = true;
    }


    // to make sure the line is see-able on the gizoms set
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        //draw a circle
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }
}
