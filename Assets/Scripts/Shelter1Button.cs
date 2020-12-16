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
    //GameObject shelter;
    // Start is called before the first frame update
    /**void Start()
    {
        Button thisButton = gameObject.GetComponent<Button>();
        shelter = GameObject.Find("Lv1 Shelter");
        thisButton.clicked.AddListener(shelter.GetComponent<shelter1Script>().AddPlant);
        print("started the listener");
    }**/
    
    /**void Update(){
        Button thisButton = gameObject.GetComponent<Button>();
        shelter = GameObject.Find("Lv1 Shelter");
        if (thisButton.clicked){
            shelter.GetComponent<shelter1Script>().AddPlant();
        }
    }**/

}
