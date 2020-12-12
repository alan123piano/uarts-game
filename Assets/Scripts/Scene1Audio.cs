using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1Audio : MonoBehaviour
{
    public AudioClip rocketLandingSound;
    public AudioClip rocketDoorOpenSound;

    void Start()
    {
        PlayAudioClip(rocketLandingSound, 0);
        PlayAudioClip(rocketDoorOpenSound, 4);
    }

    void PlayAudioClip(AudioClip clip, float delay)
    {
        AudioSource asrc = gameObject.AddComponent<AudioSource>();
        asrc.clip = clip;
        asrc.PlayDelayed(delay);
    }
}
