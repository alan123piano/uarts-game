using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Item
{
    // PRECONDITIONS: itemName has at least 1 character
    // returns null if doesn't exist in Resources/Buildings/...
    public static Dictionary<string, GameObject> bldgPrefabDict = new Dictionary<string, GameObject>();
    public static GameObject GetBuildingPrefab(string itemName)
    {
        itemName = itemName.Replace(" ", "");
        if (bldgPrefabDict.ContainsKey(itemName))
        {
            return bldgPrefabDict[itemName];
        }
        GameObject prefab = Resources.Load("Buildings/" + itemName) as GameObject;
        if (prefab == null)
        {
            return null;
        }
        bldgPrefabDict[itemName] = prefab;
        return prefab;
    }

    // PRECONDITIONS: itemName has at least 1 character
    // returns null if doesn't exist in Resources/Items/...
    public static Dictionary<string, GameObject> itemPrefabDict = new Dictionary<string, GameObject>();
    public static GameObject GetItemPrefab(string itemName)
    {
        itemName = itemName.Replace(" ", "");
        if (itemPrefabDict.ContainsKey(itemName))
        {
            return itemPrefabDict[itemName];
        }
        GameObject prefab = Resources.Load("Items/" + itemName) as GameObject;
        if (prefab == null)
        {
            return null;
        }
        itemPrefabDict[itemName] = prefab;
        return prefab;
    }
}
