using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shovelButton : MonoBehaviour
{
    public void Click(string mode)
    {
        if(mode == "start"){
            GameObject.Find("ShovelBot").GetComponent<shovelRobotMove>().activate(true);
        }
        if(mode == "stop"){
            GameObject.Find("ShovelBot").GetComponent<shovelRobotMove>().activate(false);
        }
    }
}
