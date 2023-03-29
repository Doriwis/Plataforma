using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Canvas : MonoBehaviour
{
    AudioMixer audioMIxer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SliderMusic(float volum)
    {
        audioMIxer.SetFloat("VolumenMusica", volum);
    }
}
