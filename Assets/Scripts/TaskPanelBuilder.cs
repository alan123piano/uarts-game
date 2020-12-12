using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanelBuilder : MonoBehaviour
{
    public GameObject mainframe;
    public Transform descUIContainer;
    public Transform stepsUIContainer;
    public GameObject descUIPrefab;
    public GameObject stepsUIPrefab;

    // Update is called once per frame
    void Update()
    {
        UpdateTaskPanel();
    }

    private void UpdateTaskPanel()
    {
        ClearTaskPanel();
        PopulateTaskPanel();
    }

    private void ClearTaskPanel()
    {
        foreach (Transform child in descUIContainer)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in stepsUIContainer)
        {
            Destroy(child.gameObject);
        }
    }

    private void PopulateTaskPanel()
    {
        //print("Debug Log: " + taskList[1].progress);
        List<Task> taskList = PlayerVariables.tasks;
        foreach (Task task in PlayerVariables.tasks)
        {
            if (task.visible)
            {
                GameObject label = Instantiate(descUIPrefab, descUIContainer);
                GameObject progress = Instantiate(stepsUIPrefab, stepsUIContainer);
                Text descText = label.GetComponent<Text>();
                Text progText = progress.GetComponent<Text>();
                descText.text = task.desc;
                progText.text = task.progress.ToString() + "/" + task.steps.ToString();
                if (task.progress >= task.steps)
                {
                    descText.color = new Color(0, 1, 0);
                    progText.color = new Color(0, 1, 0);
                }
            }
        }
    }
}
