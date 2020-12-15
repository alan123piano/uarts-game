using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelter1Script : MonoBehaviour
{
    private GameObject pickupRobot;
    private GameObject itemSlot;
    private GameObject popUpObject;
    private int plantOrderIndex = 1;
    private List<GameObject> plants;
    public int shelterGrowthRate = 35;
    public int maxCapacity = 6;
    // Start is called before the first frame update
    void Start()
    {
        pickupRobot = GameObject.Find("PickupRobot");
        itemSlot = GameObject.Find("itemSlot");
        popUpObject = GameObject.Find("Shelter1Popup");
    }

    public void AddPlant(){ //purple seed
        if(robotMoveScript.isGrabbing && itemSlot.transform.GetChild(0).gameObject.GetComponent<itemIdentifier>().name == "Purple Seed"){
            if(gameObject.GetComponentsInChildren<Transform>().Length < maxCapacity){
                plantOrderIndex += 1;
                itemSlot.transform.GetChild(0).gameObject.SetActive(false);
                GameObject plant = GameObject.Instantiate(Resources.Load("Plants/" + "purple0") as GameObject, gameObject.transform);
                plant.GetComponent<SpriteRenderer>().sortingOrder = plantOrderIndex;
                plant.GetComponent<plantGrowth>().growthRate = shelterGrowthRate;
            }
            else{
                PlayerVariables.sendMessage("System", "This plant shelter is full!");
            }
        }
        else{
            PlayerVariables.sendMessage("System", "You aren't holding anything!");
        } // green seed
        if(robotMoveScript.isGrabbing && itemSlot.transform.GetChild(0).gameObject.GetComponent<itemIdentifier>().name == "Green Seed"){
            if(gameObject.GetComponentsInChildren<Transform>().Length < maxCapacity){
                plantOrderIndex += 1;
                itemSlot.transform.GetChild(0).gameObject.SetActive(false);
                GameObject plant = GameObject.Instantiate(Resources.Load("Plants/" + "green0") as GameObject, gameObject.transform);
                plant.GetComponent<SpriteRenderer>().sortingOrder = plantOrderIndex;
                plant.GetComponent<plantGrowth>().growthRate = shelterGrowthRate;
            }
            else{
                PlayerVariables.sendMessage("System", "This plant shelter is full!");
            }
        }
        else{
            PlayerVariables.sendMessage("System", "You aren't holding anything!");
        }
    }

    public void CheckGrowth(){
        for(int i = 0; i < gameObject.GetComponentsInChildren<Transform>().Length; i++){
            print(i);
            PlayerVariables.sendMessage("Planter", "Plant " + i+1 + "Growth Stage: " + gameObject.transform.GetChild(i).gameObject.GetComponent<plantGrowth>().growthLevel);
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
