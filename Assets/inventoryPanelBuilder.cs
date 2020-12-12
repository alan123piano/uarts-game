using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryPanelBuilder : MonoBehaviour
{
    public GameObject mainframe;

    public GameObject textUIPrefab;
    public GameObject placeableTextUIPrefab;

    private List<Item> inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = PlayerVariables.inventory;
        StartCoroutine(refreshTasks());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void UpdateInvPanel()
    {
        ClearInvPanel();
        PopulateInvPanel();
    }

    private void ClearInvPanel()
    {
        foreach(Transform child in gameObject)
        {
            Destroy(child.gameObject);
        }

    }

    IEnumerator refreshInv() //refreshes task lsit every second to not overload program
    {
        while(true)
        {
            inventory = PlayerVariables.inventory;
            UpdateInvPanel();
            yield return new WaitForSeconds(1);
        }
    }

    private void PopulateInvPanel()
    {
        //print("Debug Log: " + taskList[1].progress);
        foreach(Item item in PlayerVariables.inventory)
        {
            if (item.placeable){
                GameObject itemUI = Instantiate(placeableTextUIPrefab, gameObject);
                itemUI.GetComponent<Text>().Text = item.name;
            }
            else
            {
                GameObject itemUI = Instantiate(textUIPrefab, gameObject);
                itemUI.GetComponent<Text>().Text = item.name;
            }
        }
    }
}

