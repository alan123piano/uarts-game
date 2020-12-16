using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redRockScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(Random.Range(0, 6) == 0){
            GameObject.Instantiate(Resources.Load("Items/RedSeed") as GameObject, new Vector3(gameObject.transform.position.x - .2f, gameObject.transform.position.y - Random.Range(.7f, 1.2f), 0f), Quaternion.Euler(0, 0, Random.Range(0, 359)));
        }
    }
}
