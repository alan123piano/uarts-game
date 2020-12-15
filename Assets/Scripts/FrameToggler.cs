using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameToggler : MonoBehaviour
{
    public GameObject frame;

    public void toggle()
    {
        frame.SetActive(!frame.activeSelf);
    }

    public void enable()
    {
        frame.SetActive(true);
    }

    public void disable()
    {
        frame.SetActive(false);
    }
}
