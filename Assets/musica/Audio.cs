using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioClip[] fxI;
    AudioClip[] musica;

    AudioSource canalMusica;
    AudioSource canalFxs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CambiarMusica()
    {
        //para musica  canalMusica.Stop();
        //cambiar musica canalMusica.clip =;
       //empieza musica
        canalMusica.Play();
    }
    //baja volumen polariza
    IEnumerator FadeOffMusic()
    {
        while (canalMusica.volume>0)
        {
            canalMusica.volume -=0.05f;
            yield return new WaitForSeconds(0.1f);

        }

       
    }
}
