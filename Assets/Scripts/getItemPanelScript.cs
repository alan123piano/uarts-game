using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getItemPanelScript : MonoBehaviour
{
    public GameObject prefab;
    private GameObject pickUpRobot;
    public void UpdatePanel()
    {
        ClearPanel();
        PopulatePanel();
    }
    private void Start(){
        pickUpRobot = GameObject.Find("PickupRobot");
    }

    private void ClearPanel()
    {
        foreach (Transform child in gameObject.GetComponent<Transform>())
        {
            Destroy(child.gameObject);
        }
    }

    private void PopulatePanel()
    {
        //print("Debug Log: " + taskList[1].progress);
        Dictionary<string, int> itemizedInv = new Dictionary<string, int>();
        foreach (string item in PlayerVariables.inventory)
        {
            if (Item.GetItemPrefab(item) != null)
            {
                if (!itemizedInv.ContainsKey(item))
                {
                    itemizedInv.Add(item, 1);
                }
                else
                {
                    itemizedInv[item]++;
                }
            }
        }
        foreach (KeyValuePair<string, int> pair in itemizedInv)
        {
            string itemName = pair.Key;
            int itemAmount = pair.Value;
            string textLabel = itemName;
            if (itemAmount > 1)
            {
                textLabel += " (" + itemAmount + ")";
            }
            GameObject itemUI = Instantiate(prefab, gameObject.GetComponent<Transform>());
            itemUI.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = textLabel;
            Button btn = itemUI.GetComponent<Button>();
            btn.onClick.AddListener(() => {
                string removed = PlayerVariables.removeFromInventory(itemName);
                if (removed != null)
                {
                    if(robotMoveScript.isGrabbing == false){
                        string newStr = itemName.Replace(" ", "");
                        GameObject pfClone = Instantiate(Resources.Load("Items/" + newStr) as GameObject);
                        robotMoveScript.isGrabbing = true;
                        robotMoveScript.chosenGameObject = pfClone;
                        GameObject.Find("PickupRobot").GetComponent<canHoldItem>().pickUp(pfClone);
                        gameObject.transform.parent.gameObject.SetActive(false);
                    }
                    else{
                        PlayerVariables.sendMessage("Robot:", "Already have something in hand!");
                    }
                }
            });
        }   
    }
}
