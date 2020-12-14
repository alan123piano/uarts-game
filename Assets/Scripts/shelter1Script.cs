using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelter1Script : MonoBehaviour
{
    public GameObject pickupRobot;
    public GameObject itemSlot;
    public GameObject popUpObject;
    private int plantOrderIndex = 1;
    private List<GameObject> plants;

    public int maxCapacity = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddPlant(){
        if(robotMoveScript.isGrabbing && itemSlot.transform.GetChild(0).gameObject.GetComponent<itemIdentifier>().name == "Purple Seed"){
            if(gameObject.GetComponentsInChildren<Transform>().Length < maxCapacity){
                plantOrderIndex += 1;
                itemSlot.transform.GetChild(0).gameObject.SetActive(false);
                GameObject plant = GameObject.Instantiate(Resources.Load("Plants/" + "purple0") as GameObject, gameObject.transform);
                plant.GetComponent<SpriteRenderer>().sortingOrder = plantOrderIndex;
                plant.GetComponent<plantGrowth>().growthRate = 35;
            }
            else{
                print("This plant shelter is full!");
            }
        }
        else{
            print("You arne't holding anything!!");
        }
    }

    public void CheckGrowth(){
        for(int i = 0; i < gameObject.GetComponentsInChildren<Transform>().Length; i++){
            print(i);
            print("Plant " + i+1 + "Growth Stage: " + gameObject.transform.GetChild(i).gameObject.GetComponent<plantGrowth>().growthLevel);
        }
    }
    // Update is called once per frame
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
