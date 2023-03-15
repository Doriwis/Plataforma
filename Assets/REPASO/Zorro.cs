using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zorro : MonoBehaviour
{
   [SerializeField]float h;
   [SerializeField] float velocity;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h=Input.GetAxisRaw("Horizontal");

        transform.Translate(new Vector3(h, transform.position.y, transform.position.z) * velocity * Time.deltaTime);

       Animacion();
    }
    void Animacion()
    {
        if (h<0)
        {
            anim.SetBool("rurring", true);
            
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (h>0)
        {
            anim.SetBool("rurring", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            anim.SetBool("rurring", false);

        }

    }
}
