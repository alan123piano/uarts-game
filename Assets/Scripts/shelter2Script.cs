using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelter2Script : MonoBehaviour
{
    private GameObject pickupRobot;
    private GameObject itemSlot;

    private GameObject energyBar;
    private GameObject popUpObject;
    private int plantOrderIndex = 1;
    private List<GameObject> plants;
    public int shelterGrowthRate = 20;
    public int maxCapacity = 10;
    // Start is called before the first frame update
    void Start()
    {
        energyBar = GameObject.Find("energyBar");
        pickupRobot = GameObject.Find("PickupRobot");
        itemSlot = GameObject.Find("itemSlot");
        popUpObject = GameObject.Find("Shelter2Popup");
    }

    public void AddPlant(){ //purple seed
        if(itemSlot.transform.GetChild(0).gameObject.GetComponent<itemIdentifier>().name == "Purple Seed"){
            if(gameObject.GetComponentsInChildren<Transform>().Length < maxCapacity){
                if(energyBar.GetComponent<energyScript>().ReadEnergy() > 10){
                    energyBar.GetComponent<energyScript>().changeEnergy(-10);
                    plantOrderIndex += 1;
                    Destroy(itemSlot.transform.GetChild(0).gameObject);
                    //itemSlot.transform.GetChild(0).gameObject.SetActive(false);
                    robotMoveScript.isGrabbing = false;
                    robotMoveScript.chosenGameObject = null;
                    PlayerVariables.sendMessage("System:", "Unidentified lifeforms detected in plant shelter. Remove immediately.");
                    GameObject plant = GameObject.Instantiate(Resources.Load("Plants/" + "purple0") as GameObject, gameObject.transform);
                    plant.GetComponent<SpriteRenderer>().sortingOrder = plantOrderIndex;
                    plant.GetComponent<PurplePlantGrowth>().growthRate = shelterGrowthRate;
                }
                else{
                    PlayerVariables.sendMessage("Shelter", "Out of Energy!");
                }
            }
            else{
                PlayerVariables.sendMessage("Plant Shelter", "This plant shelter is full!");
            }
        } //green seed
        else if(itemSlot.transform.GetChild(0).gameObject.GetComponent<itemIdentifier>().name == "Green Seed"){
            if(gameObject.GetComponentsInChildren<Transform>().Length < maxCapacity){
                if(energyBar.GetComponent<energyScript>().ReadEnergy() > 10){
                    energyBar.GetComponent<energyScript>().changeEnergy(-10);
                    plantOrderIndex += 1;
                    Destroy(itemSlot.transform.GetChild(0).gameObject);
                    //itemSlot.transform.GetChild(0).gameObject.SetActive(false);
                    robotMoveScript.isGrabbing = false;
                    robotMoveScript.chosenGameObject = null;
                    PlayerVariables.sendMessage("System:", "Celery Seed Detected. Initiating Fast-Speed Growth.");
                    GameObject plant = GameObject.Instantiate(Resources.Load("Plants/" + "green0") as GameObject, gameObject.transform);
                    plant.GetComponent<SpriteRenderer>().sortingOrder = plantOrderIndex;
                    plant.GetComponent<plantGrowth>().growthRate = shelterGrowthRate;
                }
                else{
                    PlayerVariables.sendMessage("Shelter", "Out of Energy!");
                }
            }
            else{
                PlayerVariables.sendMessage("Plant Shelter", "This plant shelter is full!");
            }
        }
        else if(itemSlot.transform.GetChild(0).gameObject.GetComponent<itemIdentifier>().name == "Brocc Seed"){
            if(gameObject.GetComponentsInChildren<Transform>().Length < maxCapacity){
                if(energyBar.GetComponent<energyScript>().ReadEnergy() > 10){
                    energyBar.GetComponent<energyScript>().changeEnergy(-10);
                    plantOrderIndex += 1;
                    Destroy(itemSlot.transform.GetChild(0).gameObject);
                    //itemSlot.transform.GetChild(0).gameObject.SetActive(false);
                    robotMoveScript.isGrabbing = false;
                    robotMoveScript.chosenGameObject = null;
                    PlayerVariables.sendMessage("System:", "Wow. Broccoli is truly an amazing plant. --System Learning--->Broccoli beneficial, but for whom?");
                    GameObject plant = GameObject.Instantiate(Resources.Load("Plants/" + "brocc0") as GameObject, gameObject.transform);
                    plant.GetComponent<SpriteRenderer>().sortingOrder = plantOrderIndex;
                    plant.GetComponent<plantGrowth>().growthRate = shelterGrowthRate;
                }
                else{
                    PlayerVariables.sendMessage("Shelter", "Out of Energy!");
                }
            }
            else{
                PlayerVariables.sendMessage("Plant Shelter", "This plant shelter is full!");
            }
        }
        else{
            PlayerVariables.sendMessage("Plant Shelter", "You aren't holding a plant!");
        }

    }

    public void Harvest(){
        int numberOfChildren = gameObject.GetComponentsInChildren<Transform>().Length;
        Destroy(gameObject.transform.GetChild(Random.Range(0, numberOfChildren - 1)).gameObject);
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
