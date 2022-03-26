using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepandRun : MonoBehaviour
{
     [SerializeField]
     private AudioClip[] clips;
     private AudioSource audioSource;

    private void Awake()
    {
        //Get the AudioSource
        audioSource = GetComponent<AudioSource>();
    }
    //"Step" in animation events
    private void Step()
    {
        //play beat sounds randomly
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }
    private AudioClip GetRandomClip()
    {
        //play beat sounds randomly
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}
