using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shelter1Button : MonoBehaviour
{
    
    public void Click(string mode)
    {
        if(mode == "plant"){
            GameObject.Find("Lv1 Shelter").GetComponent<shelter1Script>().AddPlant();
        }
        if(mode == "harvest"){
            GameObject.Find("Lv1 Shelter").GetComponent<shelter1Script>().Harvest();
        }
    }
}
