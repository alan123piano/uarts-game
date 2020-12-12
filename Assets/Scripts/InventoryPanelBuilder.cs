using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelBuilder : MonoBehaviour
{
    public GameObject mainframe;
    public GameObject textUIPrefab;
    public GameObject placeableTextUIPrefab;

    private Transform myTransform;
    private PlaceItemInWorld piiw;

    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        piiw = mainframe.GetComponent<PlaceItemInWorld>();
        PlayerVariables.addToInventory(new Item("george", true));
        UpdateInvPanel();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateInvPanel();
    }

    private void UpdateInvPanel()
    {
        ClearInvPanel();
        PopulateInvPanel();
    }

    private void ClearInvPanel()
    {
        foreach (Transform child in myTransform)
        {
            Destroy(child.gameObject);
        }

    }

    private void PopulateInvPanel()
    {
        //print("Debug Log: " + taskList[1].progress);
        foreach (Item item in PlayerVariables.inventory)
        {
            if (item.placeable){
                GameObject itemUI = Instantiate(placeableTextUIPrefab, myTransform);
                itemUI.GetComponent<Text>().text = item.name;
                Button btn = itemUI.GetComponent<Transform>().Find("Button").GetComponent<Button>() as Button;
                btn.onClick.AddListener(() => {
                    Debug.Log("hi");
                });
            }
            else
            {
                GameObject itemUI = Instantiate(textUIPrefab, myTransform);
                itemUI.GetComponent<Text>().text = item.name;
            }
        }
    }
}

