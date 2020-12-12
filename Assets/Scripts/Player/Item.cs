using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    public bool placeable;

    public static Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();

    // PRECONDITION: if [placeable], then exists Resources.Load("Items/" + [name])
    public Item(string name, bool placeable)
    {
        this.name = name;
        this.placeable = placeable;
    }

    public static int Compare(Item a, Item b)
    {
        return string.Compare(a.name, b.name);
    }

    // returns null if doesn't exist in Resources/Items/...
    public static GameObject GetPrefab(string itemName)
    {
        if (prefabDict[itemName] != null)
        {
            return prefabDict[itemName];
        }
        GameObject prefab = Resources.Load("Items/" + itemName) as GameObject;
        if (!prefab)
        {
            Debug.LogError("WARNING: The Item named " + itemName +
                " which is placeable has no associated prefab");
            return null;
        }
        prefabDict[itemName] = prefab;
        return prefab;
    }
}
