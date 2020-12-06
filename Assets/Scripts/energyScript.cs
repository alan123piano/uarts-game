using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public static float energy = 30;
    
    private void Start()
    {
        slider.value = energy;
    }
    public void changeEnergy(int deltaEnergy)
    {
        energy += deltaEnergy;
        if (energy < 0)
        {
            energy = 0;
        }
        if (energy > slider.maxValue)
        {
            energy = slider.maxValue;
        }
        print("here");
        
        //slider.value = energy;
    }

    private void Update()
    {
        slider.value = Mathf.Lerp(slider.value, energy, .3f);
    }
    public void setMaxEnergy(int maxEnergy)
    {
        slider.maxValue = maxEnergy;
    }
}
