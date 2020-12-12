using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustCollect : MonoBehaviour
{
    private GameObject mainframe;
    // Start is called before the first frame update
    void Start()
    {
        mainframe = GameObject.Find("MAINFRAME");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        PlayerVariables.dustCollected += 1;
    }
}
