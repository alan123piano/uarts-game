using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public GameObject attachedObject;
    public bool placeable;
    public string name;


    public Item(string name, bool placeable, GameObject attachedObject)
    {
        this.name = name;
        this.placeable = placeable;
        this.attachedObject = attachedObject;
    }
}
