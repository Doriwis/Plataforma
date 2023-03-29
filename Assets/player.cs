using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;




public class player : MonoBehaviour
{
    [SerializeField] int indidcelvl;
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
    [SerializeField]int salirosDisponibles;

    [Header("overlabAttackDistans")]
    [SerializeField]public float vidas;
    [SerializeField] float damageUp;
    [SerializeField] float damgeDown;
    [SerializeField] float distacia;
    [SerializeField] float defens;

    [Header("overlabAttackMele")]
    [SerializeField] Transform spawnOverAtack;
    [SerializeField] float radioAttack;
    [SerializeField] LayerMask isDamagebel;
    [SerializeField] float damgeSuelo;
    [SerializeField] float damgeSuelo2;
    [SerializeField] float damgeSuelo3;


    [Header("iventario")]
    [SerializeField] public ItemSO[] invent = new ItemSO[8];
    [SerializeField] public float exp;
    [SerializeField] float inventRadio;
    [SerializeField] LayerMask itemLayer;

    [Header("ActoInvent")]
    [SerializeField]GameObject imaInvent;


    float gravityInicial;
    Animator anim;
    [Header("Llaves portales")]
    [SerializeField]public int indicellaves;

    [SerializeField]TextMeshProUGUI textvida;

    // Start is called before the first frame update
    void Start()
    {
        
        textvida.text = "" + vidas;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        salirosDisponibles = saltosMax;
        gravityInicial= rb.gravityScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas>0)
        {
            AnimSaltar();
        }
        
        
       

        if (ItsGrounded())
        {
            if (Input.GetMouseButton(0))
            {
                rb.velocity = new Vector2(0,rb.velocity.y);
                Debug.Log("ataco");
                Ataco();
            }
                
        }

        if (!anim.GetBool("attacking"))
        {

            MovimientYAnimaciones();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            AcitveInvent();
        }
       
    }
    
    private void FixedUpdate()
    {
      if (anim.GetBool("attacking") == false&& vidas>0)
      { 
        rb.velocity = new Vector3(h * velocityMovimiento, rb.velocity.y);
        ajuste = Vector3.ClampMagnitude(rb.velocity, velocidadMaxima);
        rb.velocity = new Vector3(ajuste.x, rb.velocity.y);
      }
        
    }


    


     void MovimientYAnimaciones()
    {
        h = Input.GetAxisRaw("Horizontal");
        if (h==1)
        {
            anim.SetBool("running", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(h==-1)
        {
            anim.SetBool("running", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            anim.SetBool("running",false);
        }
    }


    void AnimSaltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && salirosDisponibles > 0) //&& anim.GetBool("attacking") == false)
        {
                

            if (salirosDisponibles>1 && ItsGrounded()==true)
            {
                Debug.Log(" suelo    2");
                anim.SetBool("falling", false);

                rb.velocity = new Vector2(rb.velocity.x, 0);
                anim.SetTrigger("jump");
                
            }
            else if (salirosDisponibles>1&& ItsGrounded()==false)
            {
                Debug.Log("No suelo    2");
                anim.SetBool("falling", false);
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector3(0, 1, 0) * ForecJumop, ForceMode2D.Impulse);
                anim.SetTrigger("jump2");
                salirosDisponibles--;
            }
            else
            {Debug.Log("No suelo     1");
                anim.SetBool("falling", false);
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector3(0, 1, 0) * ForecJumop, ForceMode2D.Impulse);
                anim.SetTrigger("jump2");
                salirosDisponibles--;
            }


            
            
                
            
            
            

        }
    }
    public void AddForceJump()
    {

        salirosDisponibles--;
        rb.AddForce(new Vector3(0, 1, 0) * ForecJumop, ForceMode2D.Impulse);
    }
 

    void Ataco()
    {
        
       anim.SetBool("attacking", true);
        
    }
   public void OverlabAttack()
    {
       Collider2D collEnemy = Physics2D.OverlapCircle(spawnOverAtack.position, radioAttack, isDamagebel);
        if (collEnemy!=null)
        {

            collEnemy.gameObject.GetComponent<enemy>().RecibirDahon(damgeSuelo);
        }
    }
    public void OverlabAttack2()
    {
       Collider2D collEnemy = Physics2D.OverlapCircle(spawnOverAtack.position, radioAttack, isDamagebel);
        if (collEnemy!=null)
        {

            collEnemy.gameObject.GetComponent<enemy>().RecibirDahon(damgeSuelo2);
        }
    }
    public void OverlabAttack3()
    {
        Collider2D collEnemy = Physics2D.OverlapCircle(spawnOverAtack.position, radioAttack, isDamagebel);
        if (collEnemy != null)
        {

            collEnemy.gameObject.GetComponent<enemy>().RecibirDahon(damgeSuelo3);
        }
    }

    public void FinAnimationAttack()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("attacking",true);
        }
        else
        {
            anim.SetBool("attacking", false);
        }
        
    }
    public void RealEnd()
    {
        anim.SetBool("attacking", false);
    }
    public void Hurt(float damgeEnemy)
    {
        vidas -= damgeEnemy;
        textvida.text = "" + vidas;
        if (vidas>0)
        {
            rb.velocity = new Vector2(0, 0);
            anim.SetTrigger("hurt");
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            anim.SetTrigger("dead");
        }
       
        
    }
    public void ResetNivel()
    {
        SceneManager.LoadScene(indidcelvl);
    }
    bool  ItsGrounded()
    {
       Collider2D call = Physics2D.OverlapCircle(pies.position, radio, Suelo);

        if (call != null) //exites cesta?
        {
            if (rb.velocity.y<=0)
            {
                salirosDisponibles = saltosMax;
                anim.SetBool("falling", false);
            }
            return true;
        }
        else
        {
            if (rb.velocity.y<=0)
            {
                anim.SetBool("falling", true);
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
            DecetItems(collision) ;
        }
    }


    //Items

    void DecetItems(Collider2D item)
    {
       ItemSO newitem=item.GetComponent<Item>().yo;

        if (newitem != null)
        {
            int a=0;
            while ( a<invent.Length)
            {
                if (invent[a] != null && invent[a].nombre == newitem.nombre)
                {
                    Debug.Log("reLLENO EN"+a);
                    invent[a].contador++;
                    a = invent.Length;
                }
                else if(invent[a] == null)
                {
                    Debug.Log("LLENO EN de 0 en" + a);
                    invent[a] = newitem;
                    a = invent.Length;
                }
                else
                {
                    a++;
                    if (a==7)
                    {
                        Debug.Log("LLENO");
                    }
                }

            }
            //for (int i = 0; i < invent.Length; i++)
            {
                //if (invent[i]!= null)
                {
                    //if (invent[i].nombre == newitem.nombre)
                    {
                       // invent[i].contador ++;
                        //i = invent.Length;
                    }
                    

                }
                //if (invent[i]==null) 
                {
                   // invent[i] = newitem;
                    //i= invent.Length;

                }
            }
        }

    }
    void AcitveInvent()
    {
        if (imaInvent.activeSelf)
        {
           
            imaInvent.SetActive(false);
        }
        else
        {
            imaInvent.SetActive(true);
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
