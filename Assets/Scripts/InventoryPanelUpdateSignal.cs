using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelUpdateSignal : MonoBehaviour
{
    public GameObject gameObjectWithInventoryPanelBuilder;
    //private InventoryPanelBuilder ipb;

    void Start()
    {
        //ipb = gameObjectWithInventoryPanelBuilder.GetComponent<InventoryPanelBuilder>();
    }

    public void SendUpdateSignal()
    {
        gameObjectWithInventoryPanelBuilder.GetComponent<InventoryPanelBuilder>().UpdateInvPanel();
    }
}
