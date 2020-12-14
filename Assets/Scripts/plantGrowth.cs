using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantGrowth : MonoBehaviour
{
    public List<Sprite> sprites;
    public int growthLevel = 0;
    public int growthRate = 35;  //in seconds -> this is the interval of growth
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Growth());
    }

    // Update is called once per frame
    
    IEnumerator Growth(){
        while(true) {
            GetComponent<SpriteRenderer>().sprite = sprites[growthLevel];
            float growthModifier = (float)(0.005f * (PlayerVariables.atmosphereContamination - 100) + 1);
            if (growthLevel < sprites.Count - 1){
                growthLevel += 1;
            }
            else{
                if (Random.Range(0, 3) == 0){
                    growthLevel -= 1;
                }
                if (growthLevel == sprites.Count - 1){
                    GameObject.Instantiate(Resources.Load("Purple Seed") as GameObject, new Vector3(gameObject.transform.position.x - .2f, gameObject.transform.position.y - Random.Range(.7f, 1.2f), 0f), Quaternion.Euler(0, 0, Random.Range(0, 359)));
                    GameObject.Instantiate(Resources.Load("Purple Seed") as GameObject, new Vector3(gameObject.transform.position.x + .2f, gameObject.transform.position.y - Random.Range(.7f, 1.2f), 0f), Quaternion.Euler(0, 0, Random.Range(0, 359)));
                }
            }
            yield return new WaitForSeconds(Random.Range(growthModifier * growthRate - 5, growthModifier * growthRate + 5));
        }
    }
    void Update()
    {
        
    }
}
