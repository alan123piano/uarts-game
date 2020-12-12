using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerVariables
{
    public static List<string> inventory = new List<string>();
    public static List<Task> tasks = new List<Task> {
        new Task("solar1", "Contruct solar panel", 1, true),
        new Task("clearAreaOfDust", "Clear general area of dust", 20, true),
        new Task("placeBox", "Place a collection box", 1, true),
        new Task("shelter1", "Construct plant shelter", 1, false),
        new Task("testSoil1", "Test soil samples", 5, false)
    };

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
}
