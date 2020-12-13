using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeRate : MonoBehaviour
{
    private GameObject energyBar;
    // Start is called before the first frame update
    void Start()
    {
        energyBar = GameObject.Find("energyBar");
        StartCoroutine(charge());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator charge()
    {
        while (true)
        {
            if(GetComponent<CapsuleCollider2D>().isTrigger == false){
                energyBar.GetComponent<energyScript>().changeEnergy(1);
            }
            yield return new WaitForSeconds(5);
        }
        

    }
}
