using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class main : MonoBehaviour
{
    public AudioClip buttonClip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonAudio()
    {
        AudioSource.PlayClipAtPoint(buttonClip, Vector3.zero);
    }
}
