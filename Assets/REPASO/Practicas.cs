using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practicas : MonoBehaviour
{
   [SerializeField] GameObject objetivo;
    [SerializeField] float velocity;
    
    void Start()
    {
        StartCoroutine(Iman());
        objetivo = GameObject.FindWithTag("Player");
        
    }

    
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, objetivo.transform.position,velocity * Time.deltaTime);
    }
    //Mover algo hacia alguien 
    IEnumerator Iman()
    {
        while (true)
        {
            while (Vector3.Distance(objetivo.transform.position, transform.position) > 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, objetivo.transform.position, velocity * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(1);
        }
       
        
        
    }
    

}
