using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practicas : MonoBehaviour
{
   [SerializeField] GameObject objetivo;
    [SerializeField] float velocity;

    [Header("overlap")]
    [SerializeField]float radio;
    [SerializeField]Transform origen;
    [SerializeField]LayerMask capa;
    
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
    void CreoOverlap()
    {
       Collider2D call =Physics2D.OverlapCircle(origen.position, radio, capa);
        if (call!=null)
        {
            call.GetComponent<Animator>().SetTrigger("duele");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(origen.position, radio);
    }

}
