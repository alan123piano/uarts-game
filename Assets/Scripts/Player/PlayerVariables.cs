using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerVariables
{
    public static List<Task> tasks = new List<Task> {
        new Task("solar1", "Contruct solar panel", 1, true),
        new Task("clearAreaOfDust", "Clear dust around area", 20, true),
        new Task("collectPurpleSeed", "Puple seeds collected", 10, false),
        new Task("placeBox", "Place an item collection box", 1, true),
        new Task("shelter1", "Construct plant shelter", 1, false),
        new Task("testSoil1", "Test soil samples", 5, false),
        new Task("shelter2", "Place upgraded plant greenhouse", 1, false),
        new Task("shovelBot", "Deploy dust shoveling Bot", 1, false)
    };
    public static List<Item> inventory = new List<Item>();

    public static double atmosphereContamination = 100;

    public static Task getTaskByName(string name)
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].name == name)
            {
                return tasks[i];
            }
        }
        return null;
    }

    public static void addTaskProgress(string name, int delta)
    {
        Task task = getTaskByName(name);
        if (task != null)
        {
            task.progress += delta;
        }
    }

    public static void changeTaskVisibility(string name, bool val)
    {
        Task task = getTaskByName(name);
        if (task != null)
        {
            task.visible = val;
        }
    }

    public static void addToInventory(Item item)
    {
        inventory.Add(item);
        inventory.Sort(Item.Compare);
        updateInventoryUI();
    }

    // returns null if item doesn't exist in inv
    public static Item findInInventory(string itemName)
    {
        foreach (Item item in inventory)
        {
            if (item.name == itemName)
            {
                return item;
            }
        }
        return null;
    }

    // returns null if item doesn't exist in inv
    public static Item removeFromInventory(string itemName)
    {
        Item item = findInInventory(itemName);
        if (item == null)
        {
            return null;
        }
        bool removed = inventory.Remove(item);
        if (removed)
        {
            updateInventoryUI();
            return item;
        }
        else
        {
            Debug.LogError("PlayerVariables is broken. >:(");
            return null;
        }
    }

    private static InventoryPanelUpdateSignal ipusCache;
    private static void updateInventoryUI()
    {
        if (ipusCache == null)
        {
            ipusCache = GameObject.Find("MAINFRAME").GetComponent<InventoryPanelUpdateSignal>();
        }
        ipusCache.SendUpdateSignal();
    }

    public static void displayDialogueOverGameObject(string msg)
    {
        // TODO
    }
}
