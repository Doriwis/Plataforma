using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("overlabAttack")]
    [SerializeField] float damgeSuelo;
    [SerializeField] float damageUp;
    [SerializeField] float damgeDown;
    [SerializeField] float distacia;
    [SerializeField] float defens;

    [Header("overlabAttack")]
    [SerializeField] Transform spawnOverAtack;
    [SerializeField] float radioAttack;
    [SerializeField] LayerMask isDamagebel;

    [Header("iventario")]
    [SerializeField] Slot[] invent = new Slot[20];
    [SerializeField] float exp;
    [SerializeField] float inventRadio;
    [SerializeField] LayerMask itemLayer;


    float gravityInicial;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        salirosDisponibles = saltosMax;
        gravityInicial= rb.gravityScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Saltar();
        
       

        if (ItsGrounded())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ataco();
            }
                
        }
       
        
            MovimientYAnimaciones();
        
       
    }
    
    private void FixedUpdate()
    {
      //if (anim.GetBool("attacking") == false)
      {  
        rb.velocity = new Vector3(h * velocityMovimiento, rb.velocity.y);
        ajuste = Vector3.ClampMagnitude(rb.velocity, velocidadMaxima);
        rb.velocity = new Vector3(ajuste.x, rb.velocity.y);
      }
        
    }


    void RersetearSalto()
    {
        
            rb.velocity = new Vector2(rb.velocity.x, 0);
    }


     void MovimientYAnimaciones()
    {
        h = Input.GetAxisRaw("Horizontal");
        if (h==1)
        {
            //anim.SetBool("running", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(h==-1)
        {
            //anim.SetBool("running", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            //anim.SetBool("running",false);
        }
    }


    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && salirosDisponibles > 0) //&& anim.GetBool("attacking") == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            //anim.SetBool("falling", true);
            rb.AddForce(new Vector3(0, 1, 0) * ForecJumop, ForceMode2D.Impulse);
            salirosDisponibles--;
            //anim.SetTrigger("jump");
            //anim.SetBool("attacking", false);

        }
    }

    void Ataco()
    {
        
       //anim.SetBool("attacking", true);
        
    }
    void LanzoAtaqueEstatick()
    {
       Collider2D collEnemy = Physics2D.OverlapCircle(pies.position, radio, Suelo);
        if (collEnemy!=null)
        {
            collEnemy.gameObject.GetComponent<enemy>().RecibirDahon(damgeSuelo);
        }
    }

    void FinAnimationAttack()
    {
        //anim.SetBool("attacking", false);
    }

    bool  ItsGrounded()
    {
       Collider2D coll= Physics2D.OverlapCircle(pies.position, radio, Suelo);
        if (coll!=null) 
        {
            if (rb.velocity.y<=0)
            {
                salirosDisponibles = saltosMax;
                //anim.SetBool("falling", false);
            }
            return true;
        }
        else
        {
            if (rb.velocity.y<0)
            {
                //anim.SetBool("falling", true);
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    { //Detec duelo
        Gizmos.DrawSphere(pies.position, radio);
        //Area deAttack
        Gizmos.DrawSphere(spawnOverAtack.position, radioAttack);
        //Iman de objetos
        Gizmos.DrawSphere(transform.position, inventRadio);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PuretaNuevoNivel"))
        {
            int proxNivel=collision.gameObject.GetComponent<portal>().GetIndiceNuevoNivel();
            SceneManager.LoadScene(proxNivel);
        }
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            
        }
    }

    //Items
    void DecetItems(Collider2D item)
    {
       ItemSO newitem=item.GetComponent<Item>().yo;

        if (newitem != null)
        {
            for (int i = 0; i < invent.Length; i++)
            {
                if (invent[i].contador!= 0)
                {
                    if (invent[i].nombre == newitem.nombre)
                    {
                        invent[i].contador ++;
                    }

                }
                if (invent[i].contador== 0) 
                {
                    invent[i].nombre = newitem.nombre;
                    invent[i].imagen = newitem.spriteImg;
                    invent[i].contador ++;

                }
            }
        }

    }
    


    //Sistema de Rampa
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
           ContactPoint2D puntoConatcto=collision.GetContact(0);
            Vector2 normalDelPlano = puntoConatcto.normal;
            float dot = Vector3.Dot(normalDelPlano, Vector3.up);
            if (ItsGrounded() && dot!=1)
            {
                rb.gravityScale = 0;
            }
            else
            {
                rb.gravityScale = gravityInicial;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            rb.gravityScale = gravityInicial;

        }
    }



}
