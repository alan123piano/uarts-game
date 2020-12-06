using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public float jumpPower;
    public float jumpTime; 
    public float speed;
    public Sprite jumpingSprite;
    public Sprite standingSprite;
    Rigidbody2D rb;
    SpriteRenderer spriteRender;
    //private Rigidbody2D robotBody = Component.GetComponent<Rigidbody2D>();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMove = Input.GetAxisRaw("Vertical");
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        Vector2 moveVectorraw = new Vector2(horizontalMove, verticalMove).normalized;
        if (horizontalMove < 0){
            spriteRender.flipX = true;
        }
        if (horizontalMove > 0){
            spriteRender.flipX = false;
        }
        rb.position += moveVectorraw * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MyJump(rb));
        }
        //GetComponent<Rigidbody2D>().velocity = moveVectorraw * speed * Time.deltaTime;
    }

    IEnumerator MyJump(Rigidbody2D rb)
    {
        spriteRender.sprite = jumpingSprite;
        float deltaPos = 0;
        float initTime = Time.time;
        //Vector3 initPos = transform.position;
        while(deltaPos >= 0)
        {
            Debug.Log("hi");
            rb.position += Vector2.up * (Mathf.Cos((Time.time - initTime) * jumpTime)) * jumpPower;
            deltaPos += Vector2.up.y * (Mathf.Cos((Time.time - initTime) * jumpTime)) * jumpPower;
            //transform.position = new Vector3(transform.position.x, transform.position.y + (-Mathf.Cos(deltaTime) * jumpPower), transform.position.z);
            yield return null;
        }

        spriteRender.sprite = standingSprite;
        print("CoCourtine Done");
    }
}