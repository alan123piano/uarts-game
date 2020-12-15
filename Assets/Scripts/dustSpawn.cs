using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustSpawn : MonoBehaviour
{
    public GameObject dustObject;
    public int numberOfParticles;
    private int[,] ranges = new int[,] {
        {-15, 58},
        {-12, 43},
    };
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfParticles; i++)
        {
            GameObject.Instantiate(dustObject, new Vector3(Random.Range(ranges[0,0], ranges[0,1]), Random.Range(ranges[1,0], ranges[1,1]), 0), Quaternion.Euler(0, 0, Random.Range(0, 359)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
