using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleVisibility : MonoBehaviour
{
    // Start is called before the first frame update
    public void toggle()
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }
        else if (gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
    }
}
