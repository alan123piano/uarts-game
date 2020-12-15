using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robotMoveScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRender;
    private Camera cam;
    public GameObject dirtChecker;
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
    
    private Vector2 speed;
    // ---- Button:
    private Button pickUpButton;

    private Button dirtSampleButton;
    // ----
    public GameObject popUpObject;
    private RectTransform popUpRect;
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        selectItemPopUpRect = selectItemPopUp.GetComponent<RectTransform>();
        speed = new Vector2(0, 0);
        pickUpButton = GameObject.Find("pickUpButton").GetComponent<Button>();
        dirtSampleButton = GameObject.Find("dirtSampleButton").GetComponent<Button>();
        popUpRect = popUpObject.GetComponent<RectTransform>();
        popUpObject.SetActive(false);
    }

    void Update()
    {
        if(isMovingToPosition){
            rb.position = Vector2.SmoothDamp(rb.position, wantedPosition, ref speed, .2f, 3);
        }
        if(isSeekingPosition){
            selectItemPopUp.SetActive(true);
            selectItemPopUpRect.position = new Vector2(Input.mousePosition.x + 50, Input.mousePosition.y + 20);
            if (Input.GetMouseButtonDown(0)){
                wantedPosition = new Vector2(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)).x, cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)).y);
                if (wantedPosition.x > transform.position.x){transform.localScale = new Vector3(1, 1, 1);}
                if (wantedPosition.x < transform.position.x){transform.localScale = new Vector3(-1, 1, 1);}
                isMovingToPosition = true;
            }
            if (Input.GetMouseButtonDown(1))
            {
                isSeekingPosition = false;
            }
        }
        else{
            selectItemPopUp.SetActive(false);
        }
        if (chosenGameObject != null && isGrabbing == false){
            isGrabbing = true;
            grab(chosenGameObject);
        }
    }

    public void findpos()
    {
        isSeekingPosition = true;
        popUpObject.SetActive(false);
    }

    private void grab(GameObject obj)
    {
        GetComponent<canHoldItem>().pickUp(obj);
    }

    public void Drop()
    {
        isMovingToPosition = false;
        GetComponent<canHoldItem>().drop(chosenGameObject);
    }
    public void GetDirtSample(){
        if (isGrabbing == false){
            dirtChecker.SetActive(true);
            grab(dirtChecker);
            StartCoroutine(CheckingDirt());
        }
        else{
            print("You hace sm in that hand o yours!");
        }
    }

    IEnumerator CheckingDirt(){
        for(byte i = 0; i < 4; i++){
            print("Checking...");
            yield return new WaitForSeconds(Random.Range(.3f, 1.2f));
        }
        double contamination = 1 - ((double)PlayerVariables.getTaskByName("clearAreaOfDust").progress / PlayerVariables.getTaskByName("clearAreaOfDust").steps);
        print("[COMPLETE] Contamination Level: " + 100 * contamination + "%");
        dirtChecker.SetActive(false);
        isGrabbing = false;
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
