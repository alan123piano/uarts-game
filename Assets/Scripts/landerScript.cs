using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class landerScript : MonoBehaviour
{
    public GameObject mainframe;
    public DialogueRunner dialoguerunner;
    public string startnode;

    private int currentTaskSet = 0;
    private List<List<string>> taskSets = new List<List<string>>{
        new List<string>(){"solar1", "clearAreaOfDust", "placeBox"},
        new List<string>(){"shelter1", "testSoil1"},
        new List<string>(){"shovelBot"}
    };

    private void Start()
    {
        PlayerVariables.addToInventory("Solar Panel");
        PlayerVariables.addToInventory("Storage Box"); 
    }

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentTaskSet >= taskSets.Count)
        {
            // we finished all of our tasks already
            return;
        }
        List<string> taskSet = taskSets[currentTaskSet];
        if (currentTasksCompleted(taskSet))
        {
            foreach (string taskName in taskSet)
            {
                Task task = PlayerVariables.getTaskByName(taskName);
                if (task != null)
                {
                    task.visible = false;
                }
            }
            currentTaskSet += 1;
            if (currentTaskSet >= taskSets.Count)
            {
                // we finished all of our tasks, yippee!
                return;
            }
            List<string> newTaskSet = taskSets[currentTaskSet];
            foreach (string taskName in newTaskSet)
            {
                Task task = PlayerVariables.getTaskByName(taskName);
                GiveCorrespondingItemToTask(task);
                if (task != null)
                {
                    task.visible = true;
                }
            }

        }
    }

    private void GiveCorrespondingItemToTask(Task task){
        if (task.name == "shelter1"){
            PlayerVariables.addToInventory("Lv1 Shelter");
            PlayerVariables.addToInventory("Dirt Checker");
        }
        if (task.name == "testSoil1"){
            PlayerVariables.addToInventory("Dirt Checker");
        }
        if (task.name == "shovelBot"){
            PlayerVariables.addToInventory("Shovel Bot");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialoguerunner.StartDialogue(startnode);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }

    private bool currentTasksCompleted(List<string> taskSet)
    {
        foreach (string taskName in taskSet)
        {
            Task task = PlayerVariables.getTaskByName(taskName);
            if (task != null)
            {
                if (task.progress < task.steps)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
