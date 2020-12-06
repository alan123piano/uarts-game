using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string name;
    public string desc;
    public int steps;
    public int progress;

    public Task(string name, string desc, int steps)
    {
        this.name = name;
        this.desc = desc;
        this.steps = steps;
        this.progress = 0;
    }
}
