using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustSpawn : MonoBehaviour
{
    public GameObject dustObject;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject.Instantiate(dustObject, new Vector3(Random.Range(-9 , 9), Random.Range(-5, 4), 0), Quaternion.Euler(0, 0, Random.Range(0, 359)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
