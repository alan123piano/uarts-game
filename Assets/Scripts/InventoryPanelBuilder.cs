using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelBuilder : MonoBehaviour
{
    public GameObject mainframe;
    public GameObject textUIPrefab;
    public GameObject placeableTextUIPrefab;

    //private Transform myTransform;
    private PlaceItemInWorld piiw;

    void Start()
    {
        //myTransform = gameObject.GetComponent<Transform>();
        piiw = mainframe.GetComponent<PlaceItemInWorld>();
        UpdateInvPanel();
    }

    public void UpdateInvPanel()
    {
        ClearInvPanel();
        PopulateInvPanel();
    }

    private void ClearInvPanel()
    {
        foreach (Transform child in gameObject.GetComponent<Transform>())
        {
            Destroy(child.gameObject);
        }
    }

    private void PopulateInvPanel()
    {
        //print("Debug Log: " + taskList[1].progress);
        Dictionary<string, int> itemizedInv = new Dictionary<string, int>();
        Dictionary<string, bool> placeableByItemName = new Dictionary<string, bool>();
        foreach (string item in PlayerVariables.inventory)
        {
            if (!placeableByItemName.ContainsKey(item))
            {
                placeableByItemName.Add(item, Item.GetBuildingPrefab(item) != null);
            }
            if (!itemizedInv.ContainsKey(item))
            {
                itemizedInv.Add(item, 1);
            }
            else
            {
                itemizedInv[item]++;
            }
        }
        foreach (KeyValuePair<string, int> pair in itemizedInv)
        {
            string itemName = pair.Key;
            int itemAmount = pair.Value;
            bool placeable = placeableByItemName[itemName];
            string textLabel = itemName;
            if (itemAmount > 1)
            {
                textLabel += " (" + itemAmount + ")";
            }
            if (placeable){
                GameObject itemUI = Instantiate(placeableTextUIPrefab, gameObject.GetComponent<Transform>());
                itemUI.GetComponent<Text>().text = textLabel;
                Button btn = itemUI.GetComponent<Transform>().Find("Button").GetComponent<Button>() as Button;
                btn.onClick.AddListener(() => {
                    piiw.Begin(itemName);
                });
            }
            else
            {
                GameObject itemUI = Instantiate(textUIPrefab, gameObject.GetComponent<Transform>());
                itemUI.GetComponent<Text>().text = textLabel;
            }
        }
    }
}

