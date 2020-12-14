﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class main : MonoBehaviour
{
    public AudioClip buttonClip;
    void Start()
    {
        StartCoroutine(FindContamination());
    }

    // Update is called once per frame

    IEnumerator FindContamination(){ //this is an Couroutine because the load of counting all the dust every frame is too much
        while(true){
            PlayerVariables.atmosphereContamination = Mathf.Round(100 * ((float)GameObject.FindGameObjectsWithTag("Dust").Length / (float)180));
            print("Contamination: " + PlayerVariables.atmosphereContamination + "%");
            yield return new WaitForSeconds(5);
        }
    }
    public void buttonAudio()
    {
        AudioSource.PlayClipAtPoint(buttonClip, Vector3.zero);
    }

}
