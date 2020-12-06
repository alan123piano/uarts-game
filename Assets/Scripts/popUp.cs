using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUp : MonoBehaviour
{
    public GameObject popUpObject;
    private RectTransform popUpRect;
    // Start is called before the first frame update
    void Start()
    {
        popUpRect = popUpObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    

    /**private void Highlight()
    {
        GameObject bubba = GameObject.Instantiate(highlight) as GameObject;
        RectTransform border = bubba.GetComponent<RectTransform>();
        border.anchoredPosition = transform.position;
    }**/

  
}
