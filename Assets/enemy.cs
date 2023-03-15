using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] Transform patrolPath;
    [SerializeField] float velocidad;
    float vidas;
    

    Transform[] destins;
    int indicesDestiny;
    Vector3 destinoactual;
    void Start()
    {
        destins = new Transform[patrolPath.childCount];
        for (int i = 0; i < destins.Length; i++)
        {
            destins[i] = patrolPath.GetChild(i);
        }

        destinoactual = destins[indicesDestiny].position;

       

        StartCoroutine(MoverAPuntoYEsperar());
    }


    void Update()
    {
        
    }
    
    IEnumerator MoverAPuntoYEsperar()
    {
        while (true)
        {

          while (transform.position!=destinoactual)
          {
            transform.position = Vector3.MoveTowards(transform.position, destinoactual, velocidad * Time.deltaTime);
            yield return null;
          }

            Contador();

          yield return new WaitForSeconds(1);
        }
      

        
    }
    void Contador()
    {
        indicesDestiny++;
        if (indicesDestiny >= destins.Length)
        {
            indicesDestiny = 0;
        }
        destinoactual = destins[indicesDestiny].position;

        float diferencia = transform.position.x - destinoactual.x;

        transform.rotation = diferencia > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        
        
    }
    public float GetVidas()
    {
        return vidas;
    }
    public void SetVidas(float Newvidas)
    {
        vidas = Newvidas;
    }
    public void RecibirDahon(float damage)
    {
        vidas -= damage;
        if (vidas<0)
        {
            Destroy(this.gameObject);
        }
    }
    
}
