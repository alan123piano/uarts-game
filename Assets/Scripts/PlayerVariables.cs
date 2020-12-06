using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    public List<string> inventory = new List<string>();
    public List<Task> tasks = new List<Task>();
    public int dustCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        //tasks.Add(new Task("solar1", "Contruct solar panel", 1));
        //tasks.Add(new Task("cleararea", "Clear area", 20));
        //tasks.Add(new Task("celery1", "Plant celery crop", 4));

        //StartCoroutine(FinishDebug1Task(10));
        //StartCoroutine(FinishDebug2Task(1));
    }

    // Update is called once per frame
    void Update()
    {
        getTaskByName("clearArea").progress = dustCollected;
    }

    /**IEnumerator FinishDebug1Task(float time)
    {
        yield return new WaitForSeconds(time);

        getTaskByName("debuglol").completed = true;
    }

    IEnumerator FinishDebug2Task(float time)
    {
        yield return new WaitForSeconds(time);

        getTaskByName("debuglol2").completed = true;
    }**/

    public Task getTaskByName(string name)
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
