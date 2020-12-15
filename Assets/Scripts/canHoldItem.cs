using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canHoldItem : MonoBehaviour
{
    private Transform itemSlot;
    // Start is called before the first frame update
    void Start()
    {
        itemSlot = transform.Find("itemSlot");
    }

    // Update is called once per frame
    
    public void pickUp(GameObject item)
    {
        item.transform.SetParent(itemSlot);
        item.transform.localPosition = Vector3.zero;
        item.transform.rotation = Quaternion.Euler(0, 0, 320);
    }
}
