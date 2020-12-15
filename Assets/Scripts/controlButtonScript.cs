using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlButtonScript : MonoBehaviour
{
    public GameObject controlPanel;
    
    // Start is called before the first frame update
    public void toggle(){
        if (controlPanel.activeSelf){
            controlPanel.SetActive(false);
        }
        else{
            controlPanel.SetActive(true);
        }
    }
}
