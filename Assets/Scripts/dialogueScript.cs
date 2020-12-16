using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class dialogueScript : MonoBehaviour
{
    public DialogueRunner dialoguerunner;
    private bool visitedTracker = false;
    public string startnode;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (visitedTracker == false){
            dialoguerunner.StartDialogue("Acid");
            visitedTracker = true;
        }
        else{
            dialoguerunner.StartDialogue("AcidAlt");
        } 
    }  
}
