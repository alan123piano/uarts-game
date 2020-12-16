using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robotMoveScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRender;
    private Camera cam;

    public AudioClip pickupSound;
    public AudioClip movingSound;
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

    private Transform itemSlot;
    void Start()
    {
        cam = Camera.main;
        itemSlot = transform.Find("itemSlot");
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
        AudioSource.PlayClipAtPoint(movingSound, Vector3.zero);
    }

    private void grab(GameObject obj)
    {
        AudioSource.PlayClipAtPoint(pickupSound, Vector3.zero);
        GetComponent<canHoldItem>().pickUp(obj);
    }

    public void Drop()
    {
        AudioSource.PlayClipAtPoint(pickupSound, Vector3.zero);
        isMovingToPosition = false;
        GetComponent<canHoldItem>().drop(chosenGameObject);
    }
    public void GetDirtSample(){
        if (PlayerVariables.findInInventory("Dirt Checker") != null){
            StartCoroutine(CheckingDirt());
        }
        else{
            PlayerVariables.sendMessage("System", "Inventory does not include a dirt checker!");
        }
    }

    IEnumerator CheckingDirt(){
        for(byte i = 0; i < 4; i++){
            PlayerVariables.sendMessage("System", "Checking...");
            yield return new WaitForSeconds(Random.Range(.3f, 1.2f));
        }
        PlayerVariables.sendMessage("System", "[COMPLETE] Contamination Level: " + PlayerVariables.atmosphereContamination + "%");
        PlayerVariables.addTaskProgress("testSoil1", 1);
        isGrabbing = false;
    }

    public void PlantWorldSeed(){
        if(itemSlot.GetChild(0).gameObject != null){
            if(itemSlot.GetChild(0).gameObject.GetComponent<worldSeedPlantScript>()){
                if(itemSlot.transform.GetChild(0).gameObject.GetComponent<itemIdentifier>().name == "Strong Purple Seed"){
                    Vector3 savePos = itemSlot.transform.GetChild(0).position;
                    Destroy(itemSlot.transform.GetChild(0).gameObject);
                    robotMoveScript.chosenGameObject = null;
                    robotMoveScript.isGrabbing = false;
                    GameObject.Instantiate(Resources.Load("Plants/purple0") as GameObject, savePos + (0.3f * Vector3.down), Quaternion.Euler(0,0,0));
                }
                if(itemSlot.transform.GetChild(0).gameObject.GetComponent<itemIdentifier>().name == "Red Seed"){
                    Vector3 savePos = itemSlot.transform.GetChild(0).position;
                    Destroy(itemSlot.transform.GetChild(0).gameObject);
                    robotMoveScript.chosenGameObject = null;
                    robotMoveScript.isGrabbing = false;
                    if(Random.Range(0, 2) == 0){
                        GameObject.Instantiate(Resources.Load("Plants/tendril0") as GameObject, savePos + (0.3f * Vector3.down), Quaternion.Euler(0,0,0));
                    }
                    else{
                        GameObject.Instantiate(Resources.Load("Plants/snake0") as GameObject, savePos + (0.3f * Vector3.down), Quaternion.Euler(0,0,0));
                    }
                }
                if(itemSlot.transform.GetChild(0).gameObject.GetComponent<itemIdentifier>().name == "Grass Seed"){
                    Vector3 savePos = itemSlot.transform.GetChild(0).position;
                    Destroy(itemSlot.transform.GetChild(0).gameObject);
                    robotMoveScript.chosenGameObject = null;
                    robotMoveScript.isGrabbing = false;
                    GameObject.Instantiate(Resources.Load("Plants/grass0") as GameObject, savePos + (0.3f * Vector3.down), Quaternion.Euler(0,0,0));
                }
                
            }
            else{
                PlayerVariables.sendMessage("Robot:", "Not currently holding an outdoor plantable seed");
            }
        }
        else{
            PlayerVariables.sendMessage("Robot:","No seed in hand");
        }
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
