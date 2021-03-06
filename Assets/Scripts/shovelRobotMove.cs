﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shovelRobotMove : MonoBehaviour
{
    public float jumpPower;
    public float jumpTime;
    public float speed;
    public Sprite jumpingSprite;
    public Sprite standingSprite;
    public GameObject highlight;
    public static bool moveActive = false;
    Rigidbody2D rb;
    SpriteRenderer spriteRender;
    // ---- Buttons:
    public GameObject enableButton;
    public GameObject disableButton;
    // Start is called before the first fsssrame update
    public GameObject popUpObject;
    void Start()
    {
        popUpObject = GameObject.Find("ShovelRobotPopup");
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        //enableButton = GameObject.Find("controlButton");
        //disableButton = GameObject.Find("stopControlButton");
        popUpObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveActive == true)
        {
            enableButton.GetComponent<Button>().interactable = false;
            disableButton.GetComponent<Button>().interactable = true;
            float verticalMove = Input.GetAxisRaw("Vertical");
            float horizontalMove = Input.GetAxisRaw("Horizontal");
            Vector2 moveVectorraw = new Vector2(horizontalMove, verticalMove).normalized;
            if (horizontalMove < 0)
            {
                spriteRender.flipX = true;
                highlight.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (horizontalMove > 0)
            {
                spriteRender.flipX = false;
                highlight.GetComponent<SpriteRenderer>().flipX = false;
            }
            rb.position += moveVectorraw * speed * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(MyJump(rb));
            }
        }
        else
        {
            enableButton.GetComponent<Button>().interactable = true;
            disableButton.GetComponent<Button>().interactable = false;
        }
    }

    public void activate(bool value)
    {
        
        popUpObject.SetActive(false);
        if (value == true)
        {
            moveActive = true;
        }
        else if (value == false)
        {
            moveActive = false;
        }
    }

    IEnumerator MyJump(Rigidbody2D rb)
    {
        spriteRender.sprite = jumpingSprite;
        float deltaPos = 0;
        float initTime = Time.time;
        while (deltaPos >= 0)
        {
            Debug.Log("hi");
            rb.position += Vector2.up * (Mathf.Cos((Time.time - initTime) * jumpTime)) * jumpPower;
            deltaPos += Vector2.up.y * (Mathf.Cos((Time.time - initTime) * jumpTime)) * jumpPower;
            yield return null;
        }

        spriteRender.sprite = standingSprite;
        print("CoCourtine Done");
    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (popUpObject.activeSelf)
            {
                popUpObject.SetActive(false);
                print(popUpObject.activeSelf);
                return;
            }

            popUpObject.SetActive(true);
            if (Input.mousePosition.x > Screen.width / 2)
            {
                popUpObject.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x - 200, Input.mousePosition.y);
            }
            else if (Input.mousePosition.x < Screen.width / 2)
            {
                popUpObject.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x + 200, Input.mousePosition.y);
            }

        }
    }
}
