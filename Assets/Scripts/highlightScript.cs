using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlightScript : MonoBehaviour
{
    public GameObject highlight;
    private void OnMouseOver()
    {
        highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
