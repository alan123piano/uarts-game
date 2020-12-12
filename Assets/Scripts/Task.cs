using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string name;
    public string desc;
    public int steps;
    public int progress;
    public bool visible;

    public Task(string name, string desc, int steps, bool visible)
    {
        this.name = name;
        this.desc = desc;
        this.steps = steps;
        this.progress = 0;
        this.visible = visible;
    }
}
