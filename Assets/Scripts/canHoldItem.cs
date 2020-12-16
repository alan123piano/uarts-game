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
    public void drop(GameObject item){
        if (item == null) {
            return;
        }
        robotMoveScript.chosenGameObject = null;
        robotMoveScript.isGrabbing = false;
        Vector3 savePos = item.transform.position;
        item.transform.parent = null;
        item.transform.position = savePos + .3f * Vector3.down;
        item.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
