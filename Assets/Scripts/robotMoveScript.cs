using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robotMoveScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRender;
    public GameObject robotPopUp;
    public GameObject highlight;
    public GameObject selectItemPopUp;
    private RectTransform selectItemPopUpRect;
    public static bool isSeekingPosition = false;
    public static bool isMovingToPosition = false;
    public static bool isGrabbing = false;
    // DEL LATER \/
    // del later /\
    public static Vector2 wantedPosition;
    public static GameObject chosenGameObject;
    public static GameObject wantedCollectObject;
    public static GameObject wantedDropObject;
    
    private Vector2 speed;
    // ---- Button:
    private Button pickUpButton;
    private Button deliverButton;
    // ----
    public GameObject popUpObject;
    private RectTransform popUpRect;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        selectItemPopUpRect = selectItemPopUp.GetComponent<RectTransform>();
        speed = new Vector2(0, 0);
        // ---- Button:
        pickUpButton = GameObject.Find("pickUpButton").GetComponent<Button>();
        popUpRect = popUpObject.GetComponent<RectTransform>();
        popUpObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (chosenGameObject != null && isMovingToPosition)
        {
            Vector2 pos = new Vector2(chosenGameObject.transform.position.x, chosenGameObject.transform.position.y);
            rb.position = Vector2.SmoothDamp(rb.position, pos, ref speed, .5f, 3);
        }
        if (isGrabbing)
        {
            grab();
        }
        if (chosenGameObject != null && chosenGameObject.transform.position.x > Screen.width / 2)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (chosenGameObject != null && chosenGameObject.transform.position.x < Screen.width / 2)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
    }

    public void findpos()
    {
        isSeekingPosition = true;
        print("orgig func");
        StartCoroutine(findPos());
    }

    IEnumerator findPos()
    {
        robotPopUp.SetActive(false);
        print(robotPopUp.name);
        selectItemPopUp.SetActive(true);
        while(isSeekingPosition)
        {
            selectItemPopUpRect.position = new Vector2(Input.mousePosition.x + 50, Input.mousePosition.y + 20);
            if (Input.GetMouseButtonDown(1))
            {
                isSeekingPosition = false;
                selectItemPopUp.SetActive(false);
            }
            yield return null;
        }
        selectItemPopUp.SetActive(false);
        robotMoveScript.isMovingToPosition = true;
        if (chosenGameObject.GetComponent<isHoldable>() && isGrabbing)
        {
            print("You are already grabbing something!");
            isSeekingPosition = true;
            robotMoveScript.isMovingToPosition = false;
            chosenGameObject = null;
            StartCoroutine(findPos());
        }
        if (chosenGameObject.GetComponent<dropOff>() && isGrabbing == false)
        {
            print("You have nothing to drop off!");
            isSeekingPosition = true;
            robotMoveScript.isMovingToPosition = false;
            chosenGameObject = null;
            StartCoroutine(findPos());
        }
        //robotMoveScript.wantedPosition = new Vector2(chosenGameObject.transform.position.x, chosenGameObject.transform.position.y);
    }
    
    /**public void moveToCollect(Vector3 pos)
    {
        //print("starting move to collect");
        pos = new Vector2(pos.x, pos.y);
        if (isMovingToPosition == true)
        {
            rb.position = Vector2.SmoothDamp(rb.position, pos, ref speed, .5f, 3);
        }
        
    }**/


    private void grab()
    {
        GetComponent<canHoldItem>().pickUp(wantedCollectObject);
    }

    public static void dropOff()
    {
        wantedCollectObject.SetActive(false);
        wantedCollectObject = null;
        wantedDropObject = null;
        
    }

    private void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            if (popUpObject.activeSelf)
            {
                popUpObject.SetActive(false);
                return;
            }
            
            popUpObject.SetActive(true);
            if (Input.mousePosition.x > Screen.width / 2)
            {
                popUpObject.transform.position = new Vector3(Input.mousePosition.x - 200, Input.mousePosition.y, 0);
            }
            else if (Input.mousePosition.x < Screen.width / 2)
            {
                popUpObject.transform.position = new Vector3(Input.mousePosition.x + 200, Input.mousePosition.y, 0);
            }

        }
    }

   
}
