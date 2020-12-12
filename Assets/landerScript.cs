using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class landerScript : MonoBehaviour
{
    public GameObject mainframe;
    public DialogueRunner dialoguerunner;
    public string startnode;
    public GameObject shipmentPanel;
    private int currentTaskSet = 1;
    private List<Task> savedTasks1 = new List<Task>(){
        new Task("solar1", "Contruct solar panel", 1),
        new Task("clearArea", "Clear general area of dust", 20),
        new Task("placeBox", "Place a collection box", 1) };
    private List<Task> savedTasks2 = new List<Task>(){
        new Task("shelter1", "Construct plant shelter", 1),
        new Task("testSoil1", "Test soil samples", 5)
    };

    private void Start()
    {
        mainframe.GetComponent<PlayerVariables>().tasks = savedTasks1;
    }

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /**if (currentTaskSet == 1 && currentTasksCompleted(savedTasks1) == true)
        {
            currentTaskSet += 1;
            int index = 0;
            foreach(Task task in savedTasks2)
            {
                mainframe.GetComponent<PlayerVariables>().tasks[index] = task;
                index += 1;
            }
        }**/
        if (currentTaskSet == 1 && currentTasksCompleted(savedTasks1) == true)
        {
            currentTaskSet += 1;
            int index = 0;
            foreach (Task task in savedTasks2)
            {
                mainframe.GetComponent<PlayerVariables>().tasks[index] = task;
                index += 1;
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            dialoguerunner.StartDialogue(startnode);
        }
        shipmentPanel.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        shipmentPanel.SetActive(false);
    }

    private bool currentTasksCompleted(List<Task> taskList)
    {
        foreach(Task task in taskList)
        {
            if (task.progress < task.steps)
            {
                return false;
            }
        }
        return true;
    }
}
