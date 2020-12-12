using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerVariables
{
    public static List<string> inventory = new List<string>();
    public static List<Task> tasks = new List<Task>();
    public static int dustCollected = 0;

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
}
