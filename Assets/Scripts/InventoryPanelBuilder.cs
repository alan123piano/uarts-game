using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelBuilder : MonoBehaviour
{
    public GameObject mainframe;
    public Transform descUIContainer;
    public Transform stepsUIContainer;
    public GameObject descUIPrefab;
    public GameObject stepsUIPrefab;

    private List<Task> taskList;

    // Start is called before the first frame update
    void Start()
    {
        taskList = PlayerVariables.tasks;
        StartCoroutine(refreshTasks());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void UpdateTaskPanel()
    {
        ClearTaskPanel();
        PopulateTaskPanel();
    }

    private void ClearTaskPanel()
    {
        foreach(Transform child in descUIContainer)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in stepsUIContainer)
        {
            Destroy(child.gameObject);
        }
    }

    IEnumerator refreshTasks() //refreshes task lsit every second to not overload program
    {
        while(true)
        {
            taskList = PlayerVariables.tasks;
            UpdateTaskPanel();
            yield return new WaitForSeconds(1);
        }
    }

    private void PopulateTaskPanel()
    {
        print("Debug Log: " + taskList[1].progress);
        for(int i = 0; i < taskList.Count; i++)
        {
            GameObject label = Instantiate(descUIPrefab, descUIContainer);
            GameObject progress = Instantiate(stepsUIPrefab, stepsUIContainer);
            RectTransform rt = label.GetComponent<RectTransform>();
            Text descText = label.GetComponent<Text>();
            Text progText = progress.GetComponent<Text>();
            descText.text = taskList[i].desc;
            progText.text = taskList[i].progress.ToString() + "/" + taskList[i].steps.ToString();
            if (taskList[i].progress >= taskList[i].steps)
            {
                descText.color = new Color(0, 1, 0);
                progText.color = new Color(0, 1, 0);
            }
        }
    }
}
