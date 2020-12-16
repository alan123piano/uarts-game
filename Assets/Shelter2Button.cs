using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shelter2Button : MonoBehaviour
{
    
    public void Click(string mode)
    {
        if(mode == "plant"){
            GameObject.Find("Lv2 Greenhouse").GetComponent<shelter2Script>().AddPlant();
        }
        if(mode == "harvest"){
            GameObject.Find("Lv2 Greenhouse").GetComponent<shelter2Script>().Harvest();
        }
    }
}
