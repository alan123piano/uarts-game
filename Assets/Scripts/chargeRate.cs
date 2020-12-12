using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeRate : MonoBehaviour
{
    public GameObject energyBar;
    // Start is called before the first frame update
    void Start()
    {
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
            //energyBar.GetComponent<energyScript>().changeEnergy(8);
            yield return new WaitForSeconds(30);
        }
        

    }
}
