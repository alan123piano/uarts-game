using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class dialogueScript : MonoBehaviour
{
    public DialogueRunner dialoguerunner;
    public string startnode;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            dialoguerunner.StartDialogue(startnode);
        }
    }
}
