using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    float h;

    [Header("Mov")]
    [SerializeField]float velocityMovimiento;
    [SerializeField] float velocidadMaxima;
    Vector3 ajuste;

    [Header("salto")]
    [SerializeField] float Force;
    [SerializeField] float ForecJumop;


    [Header("bolasuelo")]
    [SerializeField] Transform pies;
    [SerializeField] float radio;
    [SerializeField] LayerMask Suelo;
    [SerializeField] int saltosMax;
    int salirosDisponibles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        salirosDisponibles = saltosMax;
    }

    // Update is called once per frame
    void Update()
    {
         h = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)&& salirosDisponibles>0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector3(0, 1, 0) * ForecJumop,ForceMode2D.Impulse);
            salirosDisponibles--;

        }
        ItsGrounded();

        
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(h * velocityMovimiento, rb.velocity.y);
        ajuste= Vector3.ClampMagnitude(rb.velocity, velocidadMaxima);
        rb.velocity = new Vector3 (ajuste.x,rb.velocity.y);
    }

    bool  ItsGrounded()
    {
       Collider2D coll= Physics2D.OverlapCircle(pies.position, radio, Suelo);
        if (coll!=null)
        {
            if (rb.velocity.y<=0)
            {
                salirosDisponibles = saltosMax;
            }
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pies.position, radio);
    }

}
