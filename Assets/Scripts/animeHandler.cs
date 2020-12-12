using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class animeHandler : MonoBehaviour
{
    public GameObject mainframe;
    
    // Start is called before the first frame update
    private void Start()
    {

    }
    void transToGame()
    {
        mainframe.GetComponent<levelLoader>().gameTransition();
    }
}
