using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocidadMaxima;
    [SerializeField] float Force;
    [SerializeField] float ForecJumop;
    float h;
    float velocityMovimiento;
        

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>()
            ;
    }

    // Update is called once per frame
    void Update()
    {
         h = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        Vector3.ClampMagnitude(rb.velocity, velocidadMaxima);
    }
    void a()
    {
        rb.velocity = new Vector3(h* velocityMovimiento, rb.velocity.y);
    }
    
}
