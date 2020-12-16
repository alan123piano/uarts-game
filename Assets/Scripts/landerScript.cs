using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class landerScript : MonoBehaviour
{
    public GameObject mainframe;
    public DialogueRunner dialoguerunner;
    public GameObject shovelBot;
    bool initDialougeDone = false;
    bool dialougeVisitedTracker = false;
    private int currentTaskSet = 0;
    private List<List<string>> taskSets = new List<List<string>>{
        new List<string>(){"solar1", "clearAreaOfDust", "placeBox"},
        new List<string>(){"shelter1", "testSoil1"},
        new List<string>(){"shelter2"}
    };

    private void Start()
    {
        
        PlayerVariables.addToInventory("Solar Panel");
        PlayerVariables.addToInventory("Storage Box");
    }

    // Start is called before the first frame update

    private void importBot(){
        shovelBot.transform.position = Vector3.zero;
    }
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
            PlayerVariables.addToInventory("Green Seed");
            PlayerVariables.addToInventory("Green Seed");
            PlayerVariables.addToInventory("Green Seed");
            PlayerVariables.addToInventory("Green Seed");
        }
        if (task.name == "testSoil1"){
            PlayerVariables.addToInventory("Dirt Checker");
        }
        if (task.name == "shovelBot"){
            PlayerVariables.addToInventory("Shovel Bot");
        }
        if (task.name == "shelter2"){
            PlayerVariables.addToInventory("Lv2 Greenhouse");
            PlayerVariables.addToInventory("Brocc Seed");
            PlayerVariables.addToInventory("Brocc Seed");
            PlayerVariables.addToInventory("Brocc Seed");
            PlayerVariables.addToInventory("Brocc Seed");
            PlayerVariables.addToInventory("Green Seed");
            importBot();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(initDialougeDone == false){
            dialoguerunner.StartDialogue("Bread");
            initDialougeDone = true;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (dialougeVisitedTracker == false){
                dialoguerunner.StartDialogue("Start");
                dialougeVisitedTracker = true;
            }
            else{
                dialoguerunner.StartDialogue("StartAlt");
            }
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
