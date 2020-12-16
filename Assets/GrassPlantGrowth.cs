using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPlantGrowth : MonoBehaviour
{
    public List<Sprite> sprites;
    public int growthLevel = 0;
    public int growthRate;  //in seconds -> this is the interval of growth
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Growth());
    }

    // Update is called once per frame
    
  IEnumerator Growth(){
        bool alreadySpread = false;
        while(true) {
            GetComponent<SpriteRenderer>().sprite = sprites[growthLevel];
            if (growthLevel < sprites.Count - 1){
                growthLevel += 1;
            }
            else{ //if fully grown
                if (growthLevel == (sprites.Count - 1) && alreadySpread == false){
                    alreadySpread = true;
                    for(int j = 0; j < Random.Range(0, 3); j++){
                        GameObject.Instantiate(Resources.Load("Plants/grass0") as GameObject, new Vector3(gameObject.transform.position.x + Random.Range(-5f, 5f), gameObject.transform.position.y + Random.Range(-5f, 5f), 0f), Quaternion.Euler(0, 0, 0));
                    }
                }
                if(Random.Range(0, 5) == 0){
                    GetComponent<SpriteRenderer>().sprite = sprites[0];
                }
            }
            yield return new WaitForSeconds(Random.Range(growthRate - 1, growthRate + 1));
        }

    }
    
}
